using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform Target;
    public Transform Team;
    public CarMoveSystem CarMoveSystem;
    public CarInfo CarInfo;

    private void Start()
    {
        CarInfo = GetComponent<CarInfo>();
        CarMoveSystem = GetComponent<CarMoveSystem>();
    }

    private void Update()
    {
        FoundTarget();
    }

    public void FoundTarget()
    {   
        Target = GameManager.Instance.Player().GetComponent<Transform>();
        Transform wayPoint = GameManager.Instance.WayPoints;

        Vector3 target = transform.InverseTransformPoint(Target.position).normalized;
        //Vector3 team = transform.InverseTransformPoint(Team.position).normalized;
        Vector3 way = transform.InverseTransformPoint(CarInfo.TargetPoint.position).normalized;

        if (Vector3.Distance(Target.position, transform.position) <= 30) CarMoveSystem.MoveSystem(1, target.x);
        //else if(Vector3.Distance(Team.position, transform.position) <= 30) CarMoveSystem.MoveSystem(1, team.x * -1);
        else CarMoveSystem.MoveSystem(1, way.x);
    }
}
