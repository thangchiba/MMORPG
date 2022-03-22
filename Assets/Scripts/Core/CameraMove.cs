using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MMORPG.Core
{
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
            //Camera will follow player without rotation
            gameObject.transform.position = player.transform.position;
        }
    }
}