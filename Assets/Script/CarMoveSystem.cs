using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WheelInfo
{
    public WheelCollider LeftWheel;
    public WheelCollider RightWheel;
    public bool Motor;
    public bool Steering;
}

public class CarMoveSystem : MonoBehaviour
{   
    public List<WheelInfo> WheelInfo = new List<WheelInfo>();

    public float MaxMotor;
    public float MaxSteer;
    public float BrakeForce;

    public void MoveSystem(float motorTorque, float steer, bool bIsbrake = false)
    {
        foreach(var wheel in WheelInfo)
        {
            if(wheel.Motor)
            {
                wheel.LeftWheel.motorTorque = motorTorque * MaxMotor;
                wheel.RightWheel.motorTorque = motorTorque * MaxMotor;
            }

            if(wheel.Steering)
            {
                wheel.LeftWheel.steerAngle = steer * MaxSteer;
                wheel.RightWheel.steerAngle = steer * MaxSteer;
            }

            float isBrake = bIsbrake ? 1 : 0;
            wheel.LeftWheel.brakeTorque = BrakeForce * isBrake;
            wheel.RightWheel.brakeTorque = BrakeForce * isBrake;

            WheelPos(wheel.LeftWheel);
            WheelPos(wheel.RightWheel);
        }
    }

    void WheelPos(WheelCollider wheel)
    {
        Transform tier = wheel.transform.GetChild(0);
        wheel.GetWorldPose(out Vector3 pos, out Quaternion rot);
        tier.position = pos;
        tier.rotation = rot;
    }

}
