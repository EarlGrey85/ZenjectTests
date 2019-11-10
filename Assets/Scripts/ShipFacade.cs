using System;
using Zenject;
using UnityEngine;

public class ShipFacade : IPoolable<IMemoryPool>, IDisposable
{
    ShipHealthHandler _healthHandler;
    private IMemoryPool _memoryPool;

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

    public void OnDespawned()
    {
        _memoryPool = null;
    }

    public void OnSpawned(IMemoryPool memoryPool)
    {
        _memoryPool = memoryPool;
    }

    public void Dispose()
    {
        _memoryPool.Despawn(this);
    }
}
