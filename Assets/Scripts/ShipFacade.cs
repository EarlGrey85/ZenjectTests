using Zenject;
using UnityEngine;

public class ShipFacade
{
    ShipHealthHandler _healthHandler;

    [Inject]
    public Transform Transform { get; private set; }

    [Inject]
    public void Construct(ShipHealthHandler healthHandler)
    {
        _healthHandler = healthHandler;
    }

    public void TakeDamage(float damage)
    {
        _healthHandler.TakeDamage(damage);
    }

    public class Factory : PlaceholderFactory<float, ShipFacade>
    {
    }
}
