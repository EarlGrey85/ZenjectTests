using UnityEngine;
using Zenject;

public class GameRunner : ITickable
{
    private readonly ShipFacade.Factory _shipFactory;

    private Vector3 lastShipPosition;

    public GameRunner(ShipFacade.Factory shipFactory)
    {
        _shipFactory = shipFactory;
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var ship = _shipFactory.Create(Random.RandomRange(2, 20));
            ship.Transform.position = lastShipPosition;

            lastShipPosition += Vector3.forward * 2;
        }
    }
}
