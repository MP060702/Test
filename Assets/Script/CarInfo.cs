using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInfo : MonoBehaviour
{
    public Transform TargetPoint;
    public int TargetIndex = 0;
    public bool IsReverse;
    public bool IsFinish;
    public int Laps;

    private void Start()
    {
        FoundWay();
    }

    private void Update()
    {
        FoundWay();
    }

    public void FoundWay() 
    {
        if (IsReverse == false) TargetPoint = GameManager.Instance.WayPoints.GetChild(OutIndex(TargetIndex));
        else TargetPoint = GameManager.Instance.WayPoints.GetChild(OutIndex(TargetIndex - 1));

        if (Vector3.Distance(TargetPoint.position, transform.position) <= 30)
        {
            if (IsReverse == false) TargetIndex++;
            else TargetIndex--;

            if (GameManager.Instance.WayPoints.childCount == TargetIndex - 1) IsFinish = true;

            TargetIndex = OutIndex(TargetIndex);
        }
    }

    public int OutIndex(int input)
    {
        if (0 > input) return GameManager.Instance.WayPoints.childCount + input;
        if (GameManager.Instance.WayPoints.childCount <= input) return input %= GameManager.Instance.WayPoints.childCount;
        return input;
    }

}
