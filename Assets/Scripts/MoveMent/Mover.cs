using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MMORPG.Core;
using MMORPG.Combat;

namespace MMORPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        NavMeshAgent navMeshAgent;
        Animator animator;
        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponentInChildren<Animator>();
        }

        void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            //Dependence Inversion Control. When start a action, other doing action willbe stop
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        //Move to a point
        public void MoveTo(Vector3 destination)
        {
            //Set target that object will chase
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        //Cancel chase
        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            //Get moving speed with global velocity
            Vector3 velocity = navMeshAgent.velocity;
            //Get moving speed compare with global velocity
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            //Get forward speed
            float speed = localVelocity.z;
            //Set forward speed to BlendTree
            animator.SetFloat("moveSpeed", speed);
        }
    }
}