using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        this.transform.position = player.transform.position;
    }
}
