using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MMORPG.Movement;
using MMORPG.Combat;

namespace MMORPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        public bool disableControl = false;
        Mover mover;
        Fight fight;
        private void Awake()
        {
            Application.targetFrameRate = 120;
        }
        private void Start()
        {
            mover = GetComponent<Mover>();
            fight = GetComponent<Fight>();
        }
        private void Update()
        {
            if (disableControl) return;
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            //Get all object hitted on straight line 
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null || target.tag == "Player") continue;

                if (Input.GetMouseButtonDown(0))
                {
                    fight.Attack(target);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            if (hits.Length != 0)
            {
                if (Input.GetMouseButton(0))
                {
                    mover.StartMoveAction(hits[0].point);
                }
                return true;
            }
            return false;
        }

        //straight line come from center of camera to mouse clicked point
        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}