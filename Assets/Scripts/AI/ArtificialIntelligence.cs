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
        Vector3 guardingPosition;
        CombatTarget player;
        Fight fight;
        Mover mover;
        private void Start()
        {
            //Set default guarding position is initialized position
            guardingPosition = transform.position;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatTarget>();
            fight = GetComponent<Fight>();
            mover = GetComponent<Mover>();
        }
        private void Update()
        {
            if (!InChaseRange())
            {
                //Cancel Fight and Move back to guarding position
                mover.StartMoveAction(guardingPosition);
                return;
            }
            fight.Attack(player);
        }

        private bool InChaseRange()
        {
            float distance = CalcRange();
            return distance < chaseRange;
        }

        float CalcRange()
        {
            return Vector3.Distance(player.transform.position, transform.position);
        }

        //Unity draw gizmos
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            //ChaseRange draw
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
    }
}
