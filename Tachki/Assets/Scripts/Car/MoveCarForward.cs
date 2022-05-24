using UnityEngine;

public class MoveCarForward : RaycastCar
{
    [SerializeField] private CarData carData;
    [SerializeField] private Rigidbody sphereRB;
    [SerializeField] private float gravityModifier = 30f;

    [SerializeField] private float minDrag = 0f;
    [SerializeField] private float maxDrag = 4f;

    private float speed;
    void Start()
    {
        speed = carData.speed;
        sphereRB.transform.parent = null;
    }
    void Update()
    {
        transform.position = sphereRB.transform.position;
    }
    private void FixedUpdate()
    {
        Raycaster();
        if (isGrounded)
        {
            sphereRB.AddForce(transform.forward * speed);
            sphereRB.drag = maxDrag;
        }
        else
        {
            sphereRB.AddForce(transform.up * -gravityModifier);
            sphereRB.drag = minDrag;
        }
    }
}