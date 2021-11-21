using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public bool isAI = false;
    public float input = 0f;
    private bool isGrounded;
    private float steering;
    private Car car;
    private Transform car_tr;

    [SerializeField] private LayerMask Ground;
    [SerializeField] private Rigidbody car_rb;
    [SerializeField] private float max_speed;
    [SerializeField] private float max_steering;
    [SerializeField] private float gravity_modify = -50f;
    [SerializeField] private Button left;
    [SerializeField] private Button right;

    void Awake()
    {
        car = GetComponent<Car>();
        car_tr = GetComponent<Transform>();
        car_rb.transform.parent = null;
        left = GameObject.Find("L_Button").GetComponent<Button>();
        right = GameObject.Find("R_Button").GetComponent<Button>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(car_tr.position, -car_tr.up, out hit, 1f, Ground);
        car_tr.position = car_rb.transform.position;
        if(!isAI)
            steering = input * max_steering;
        else
        {
            //AIController();
        }

        if (isGrounded)
        {
            car.MoveForward(car_tr, car_rb, max_speed, hit);
            car.Rotate(car_tr, steering);
        }
        else
        {
            car_rb.AddForce(car_tr.up * gravity_modify);
        }
    }
    
}
