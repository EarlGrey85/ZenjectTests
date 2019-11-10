using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject shipPrefab;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GameRunner>().AsSingle();

        Container.BindFactory<float, Ship, Ship.Factory>().FromSubContainerResolve().ByNewContextPrefab<ShipInstaller>(shipPrefab);
    }
}