using UnityEngine;
using Zenject;

public class GameRunner : ITickable
{
    readonly Ship _ship;
    private readonly Ship.Factory _shipFactory;

    private Vector3 lastShipPosition;

    public GameRunner(Ship.Factory shipFactory)
    {
        _shipFactory = shipFactory;
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var ship = _shipFactory.Create(Random.RandomRange(2, 20));
            ship.transform.position = lastShipPosition;

            lastShipPosition += Vector3.forward * 2;
        }
    }
}
