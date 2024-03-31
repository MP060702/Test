using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject Prefab;
    public float SpawnLate = 2.5f;
    private List<GameObject> _CurrentNPC = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("Spawn", 5f, SpawnLate);
    }

    public void Spawn()
    {      
        for (int i = _CurrentNPC.Count - 1; i >= 0; i--)
        {
            if (_CurrentNPC[i] == null)
            {
                _CurrentNPC.RemoveAt(i);
            }
        }

        if (_CurrentNPC.Count >= 3) return;

        int PlayerWayIndex = GameManager.Instance.Player().GetComponent<CarInfo>().TargetIndex;

        var temp = GameManager.Instance.Player().GetComponent<CarInfo>();
        bool IsReverse = System.Convert.ToBoolean(Random.Range(0, 2));
        Vector3 pos = GameManager.Instance.WayPoints.GetChild(temp.OutIndex(PlayerWayIndex + (IsReverse ? 4 : -2))).position + Vector3.up;
        Debug.Log(GameManager.Instance.WayPoints.GetChild(temp.OutIndex(PlayerWayIndex + (IsReverse ? 4 : -2))));
        Quaternion dir = Quaternion.LookRotation(GameManager.Instance.WayPoints.GetChild(temp.OutIndex(PlayerWayIndex + (IsReverse ? 3 : -1))).position - pos);

        CarInfo instance = Instantiate(Prefab, pos, dir).GetComponent<CarInfo>();

        instance.GetComponent<CarMoveSystem>().MaxMotor = GameManager.Instance.Player().GetComponent<CarMoveSystem>().MaxMotor + 50;

        instance.IsReverse = IsReverse;

        instance.GetComponent<Rigidbody>().AddForce(10000 * instance.transform.forward, ForceMode.Impulse);

        instance.TargetIndex = instance.OutIndex(PlayerWayIndex + (IsReverse ? 3 : -1));

        _CurrentNPC.Add(instance.gameObject);
    }
}