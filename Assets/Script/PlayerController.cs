using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CarMoveSystem CarMoveSystem;
    public CarInfo CarInfo;

    private void Start()
    {
        CarInfo = GetComponent<CarInfo>();
        CarMoveSystem = GetComponent<CarMoveSystem>();
    }

    private void Update()
    {
        MoveInput();
    }

    void MoveInput()
    {
        float motorTorque = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        bool isbrake = Input.GetKey(KeyCode.Space);

        CarMoveSystem.MoveSystem(motorTorque, steer, isbrake);
    }

}
