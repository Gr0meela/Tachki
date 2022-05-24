using UnityEngine;

public class CarAI : RaycastCar
{
    [SerializeField] private CarData carData;
    [SerializeField] private PointChecker button;
    private float rotationSpeed;
    private int direction;
    private void OnEnable()
    {
        button = FindObjectOfType<PointChecker>();
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
