using System;
using System.Collections;
using System.Collections.Generic;
using MMORPG.Combat;
using MMORPG.Movement;
using UnityEngine;

namespace MMORPG.Combat
{
    public class ArtificialIntelligence : MonoBehaviour
    {
        [SerializeField] float chaseRange = 5f;
        CombatTarget player;
        Fight fight;
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatTarget>();
            fight = GetComponent<Fight>();
        }
        private void Update()
        {
            if (!InChaseRange())
            {
                fight.Cancel();
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
