using UnityEngine;

public class SlopeCar : RaycastCar
{
    void Update()
    {
        Raycaster();
    }
    protected override void Raycaster()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, groundLayer);
        transform.rotation *= Quaternion.FromToRotation(transform.up, hit.normal);
    }
}
