using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MMORPG.Move
{
    public class Mover : MonoBehaviour
    {
        void Update()
        {
            UpdateAnimator();
        }
        public void MoveToPoint(Vector3 point)
        {
            GetComponent<NavMeshAgent>().destination = point;
        }
        private void UpdateAnimator()
        {
            //Grabbing global coordinates move speed
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            //Calc local move speed by global
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            //Local move speed
            float moveSpeed = localVelocity.z;
            //Set Animator move speed
            GetComponent<Animator>().SetFloat("moveSpeed", moveSpeed, 0.05f, Time.deltaTime);
        }
    }
}