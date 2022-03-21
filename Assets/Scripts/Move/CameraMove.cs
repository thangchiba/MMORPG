using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraMove : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void LateUpdate()
    {
        MoveFollowPlayer();
    }

    private void MoveFollowPlayer()
    {
        gameObject.transform.position = player.transform.position;
    }
}
