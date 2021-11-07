using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> axleInfos; // the information about each individual axle
    [SerializeField] private float maxMotorTorque; // maximum torque the motor can apply to wheel
    [SerializeField] private float maxSteeringAngle; // maximum steer angle the wheel can have
    public void MoveForward()
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = maxMotorTorque;
                axleInfo.rightWheel.motorTorque = maxMotorTorque;
            }
        }
    }
    public void Rotate(float steering)
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering * maxSteeringAngle;
                axleInfo.rightWheel.steerAngle = steering * maxSteeringAngle;
            }
        }
    }
}