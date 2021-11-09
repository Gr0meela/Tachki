using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public void MoveForward(Transform tr, Rigidbody rb, float speed, RaycastHit hit)
    {
        rb.AddForce(tr.right * speed, ForceMode.Acceleration);
        tr.rotation *= Quaternion.FromToRotation(tr.up, hit.normal);
    }

    public void Rotate(Transform tr, float steering)
    {
        tr.Rotate(0, steering, 0);
    }
}
