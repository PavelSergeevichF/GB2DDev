using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car
{
    public float speed { get; private set; }
    public Car(float _speed)
    {
        speed = _speed;
    }
}
