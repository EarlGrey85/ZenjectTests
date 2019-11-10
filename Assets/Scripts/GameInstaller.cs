using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject shipPrefab;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GameRunner>().AsSingle();

        Container.BindFactory<float, ShipFacade, ShipFacade.Factory>().FromSubContainerResolve().ByNewPrefabInstaller<ShipInstaller>(shipPrefab);
    }
}