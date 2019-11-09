using System;
using UnityEngine;
using Zenject;

public class ShipFacade : IPoolable<IMemoryPool>, IDisposable
{
    private IMemoryPool _pool;
    private readonly ShipHealthHandler _healthHandler;
    private readonly ShipInputHandler _shipInputHandler;

    public ShipFacade(ShipHealthHandler healthHandler, ShipInputHandler shipInputHandler)
    {
        _healthHandler = healthHandler;
        _shipInputHandler = shipInputHandler;
    }

    public void TakeDamage(float damage)
    {
        _healthHandler.TakeDamage(damage);
    }

    [Inject]
    public Transform Transform
    {
        get; private set;
    }

    public void OnDespawned()
    {
        _pool = null;
    }

    public void OnSpawned(IMemoryPool pool)
    {
        _pool = pool;
    }

    public void Dispose()
    {
        _pool.Despawn(this);
    }

    public class Factory : PlaceholderFactory<float, ShipFacade>
    {
    }
}