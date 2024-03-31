using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
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
        AIMove();
    }

    public void AIMove()
    {
        Vector3 wayTarget = transform.InverseTransformPoint(CarInfo.TargetPoint.position);
        wayTarget = wayTarget.normalized;
        CarMoveSystem.MoveSystem(1, wayTarget.x);
    }
}
