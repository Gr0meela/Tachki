using UnityEngine;

public class RaycastCar : MonoBehaviour
{
    [SerializeField] protected LayerMask groundLayer;
    protected bool isGrounded;

    protected virtual void Raycaster()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, groundLayer);
    }
}
