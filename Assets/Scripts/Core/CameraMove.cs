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

        // change this value to get desired smoothness
        public float SmoothTime = 0.8f;

        // This value will change at the runtime depending on target movement. Initialize with zero vector.
        private Vector3 velocity = Vector3.zero;
        private void MoveFollowPlayer()
        {
            //Camera will follow player without rotation
            //gameObject.transform.position = player.transform.position;
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, SmoothTime);
        }
    }
}