using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    GameObject ShipPrefab;

    [SerializeField] private GameObject[] ships;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GameRunner>().AsSingle();

        Container.BindFactory<float, ShipFacade, ShipFacade.Factory>()
            .FromSubContainerResolve().ByNewGameObjectMethod(SpawnShip); //<ShipInstaller>(ships[Random.Range(0, ships.Length)]);

        //Container.BindFactory<float, ShipFacade, ShipFacade.Factory>().FromSubContainerResolve()
        //    .ByInstaller<ShipInstaller>();

        Container.BindFactory<float, ShipFacade, ShipFacade.Factory>().FromSubContainerResolve().ByNewContextPrefab<ShipInstaller>(ShipPrefab);
    }

    private void SpawnShip(DiContainer container, float speed)
    {
        container.Bind<ShipFacade>().AsSingle();
        container.Bind<Transform>().FromComponentOnRoot();
        var shipPrefab = ships[Random.Range(0, ships.Length)];
        var ship = container.InstantiatePrefab(shipPrefab);
        container.Bind<ShipHealthHandler>().FromNewComponentOn(ship).WhenInjectedInto<ShipFacade>();
        container.BindInstance(speed).WhenInjectedInto<ShipInputHandler>();
    }
}