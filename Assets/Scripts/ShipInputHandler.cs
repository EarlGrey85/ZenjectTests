using UnityEngine;
using System.Collections;
using Zenject;

public class ShipInputHandler : ITickable
{
    private readonly Transform _transform;
    private readonly float _speed;

    public ShipInputHandler(float speed, Transform transform)
    {
        _transform = transform;
        _speed = speed;
    }

    public void Tick()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _transform.position += Vector3.forward * _speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _transform.position -= Vector3.forward * _speed * Time.deltaTime;
        }
    }
}