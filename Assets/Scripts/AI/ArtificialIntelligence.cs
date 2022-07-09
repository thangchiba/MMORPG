using System;
using System.Collections;
using System.Collections.Generic;
using MMORPG.Combat;
using MMORPG.Core;
using MMORPG.Movement;
using UnityEngine;

namespace MMORPG.Combat
{
    public class ArtificialIntelligence : MonoBehaviour
    {
        [SerializeField] float chaseRange = 5f;
        //[SerializeField] float waitTimeBackToPatrolling = 3f;
        CombatTarget player;
        Fight fight;
        Patrol patrol;
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatTarget>();
            fight = GetComponent<Fight>();
            patrol = GetComponentInParent<Patrol>();
        }
        private void Update()
        {
            if (!InChaseRange())
            {
                //Cancel Fight and Move back to patrol
                patrol.StartPatrolAction();
                return;
            }
            fight.Attack(player);
        }

        private bool InChaseRange()
        {
            float distance = CalcRange();
            return distance < chaseRange;
        }

        //Caculating range from player to minion
        float CalcRange()
        {
            return Vector3.Distance(player.transform.position, transform.position);
        }

        //Unity draw chase range gizmos
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            //ChaseRange draw
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
    }
}
