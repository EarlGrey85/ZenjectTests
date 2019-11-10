using UnityEngine;
using Zenject;

public class ShipInstaller : MonoInstaller
{
    [SerializeField]
    [InjectOptional]
    private float _speed;

    public override void InstallBindings()
    {
        Container.BindInstance(_speed).WhenInjectedInto<ShipInputHandler>();
    }
}