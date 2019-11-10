using UnityEngine;
using Zenject;

public class GameRunner : ITickable
{
    readonly ShipFacade.Factory _shipFactory;

    Vector3 lastShipPosition;

    public GameRunner(ShipFacade.Factory shipFactory)
    {
        _shipFactory = shipFactory;
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var ship = _shipFactory.Create(Random.Range(2.0f, 20.0f));

            ship.Transform.position = lastShipPosition;
            Debug.Log(ship.Transform);
            Debug.Log(lastShipPosition);

            lastShipPosition += Vector3.forward * 2;
        }
    }
}