using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //private bool isAI = false;
    private bool isGrounded;
    private Car car;
    public LayerMask Ground;
    private Transform car_tr;
    [SerializeField] private Rigidbody car_rb;
    [SerializeField] private float max_speed;
    [SerializeField] private float max_steering;
    private float steering;

    void Awake()
    {
        car = GetComponent<Car>();
        car_tr = GetComponent<Transform>();
        car_rb.transform.parent = null;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(car_tr.position, -car_tr.up, out hit, 1f, Ground);
        steering = Input.GetAxis("Horizontal") * max_steering;
        car_tr.position = car_rb.transform.position;

        if (isGrounded)
        {
            car.MoveForward(car_tr, car_rb, max_speed, hit);
            car.Rotate(car_tr, steering);
        }
        else
        {
            car_rb.AddForce(car_tr.up * -50f);
        }
    }
}
