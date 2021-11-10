using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public void MoveForward(Transform tr, Rigidbody rb, float speed, RaycastHit hit)
    {
        rb.AddForce(tr.right * speed, ForceMode.Acceleration);
        Quaternion rotateTo = Quaternion.FromToRotation(tr.up, hit.normal) * tr.rotation;
        tr.rotation = Quaternion.Slerp(tr.rotation, rotateTo, 0.2f);
    }

    public void Rotate(Transform tr, float steering)
    {
        tr.Rotate(0, steering, 0);
    }
}
