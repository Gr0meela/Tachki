using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    private CarController car;
    private float steering;
    private bool isAI = false;
    void Awake()
    {
        car = GetComponent<CarController>();
    }
    void FixedUpdate()
    {
        if(!isAI)
        {
            steering = Input.GetAxis("Horizontal");
        }
        car.MoveForward();
        car.Rotate(steering);
    }
}
