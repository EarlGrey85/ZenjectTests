using UnityEngine;
using Zenject;

public class ShipInputHandler : ITickable
{
    readonly Transform _transform;
    private float _speed;

    public ShipInputHandler(
        float speed,
        Transform transform)
    {
        _transform = transform;
        _speed = speed;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void Tick()
    {
        Debug.Log(_speed);

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