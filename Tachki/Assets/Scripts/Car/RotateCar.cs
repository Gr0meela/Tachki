using UnityEngine;

public class RotateCar : RaycastCar
{
    [SerializeField] private CarData carData;
    private RotationButton button;
    private float rotationSpeed;
    private int direction;
    void Start()
    {
        button = FindObjectOfType<RotationButton>();
        rotationSpeed = carData.rotationSpeed;
    }
   void Update()
    {
        direction = button.direction;
        Raycaster();
        if (isGrounded)
            transform.Rotate(0, direction * rotationSpeed * Time.deltaTime, 0, Space.World);
    }
}