using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    public Transform WayPoints;
    public GameObject PlayerObj;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public PlayerController Player() { return PlayerObj.GetComponent<PlayerController>();}

}
