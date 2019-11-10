using UnityEngine;
using System.Collections;
using Zenject;

public class ShipInputHandler : MonoBehaviour
{
    [Inject]
    float _speed;

    public void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += Vector3.forward * _speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position -= Vector3.forward * _speed * Time.deltaTime;
        }
    }
}