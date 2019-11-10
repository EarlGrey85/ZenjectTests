using UnityEngine;
using Zenject;

public class ShipInstaller : Installer<ShipInstaller>
{
    readonly float _speed;

    public ShipInstaller(
        [InjectOptional]
        float speed)
    {
        _speed = speed;
    }

    public override void InstallBindings()
    {
        Container.Bind<ShipFacade>().AsSingle();
        Container.Bind<Transform>().FromComponentOnRoot();
        Container.BindInterfacesAndSelfTo<ShipInputHandler>().AsSingle();
        Container.BindInstance(_speed).WhenInjectedInto<ShipInputHandler>();
        Container.Bind<ShipHealthHandler>().FromNewComponentOnRoot().AsSingle();
    }

    private ShipFacade MakeShip()
    {
        var ships = Resources.LoadAll<GameObject>("");
        var obj = Container.InstantiatePrefab(ships[Random.Range(0, ships.Length)]);

        return null;
    }
}