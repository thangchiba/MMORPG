using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MMORPG.Movement;
using MMORPG.Combat;
using UnityEngine.EventSystems;

namespace MMORPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        public bool disableControl = false;
        Mover mover;
        Fight fight;
        private void Awake()
        {
            Application.targetFrameRate = 60;
            mover = GetComponent<Mover>();
            fight = GetComponent<Fight>();
        }
        private void Update()
        {
            if (disableControl) return;
            if (InteractWithUI()) return;
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        enum CursorType
        {
            None,
            Movement,
            Combat,
            Pickup
        }

        [Serializable]
        class CursorMapping
        {
            public CursorType cursorType;
            public Texture2D texture;
            public Vector2 hotspot;
        }

        void SetCursor(CursorType cursorType)
        {
            foreach (CursorMapping cursor in cursorMappings)
            {
                if (cursor.cursorType == cursorType)
                {
                    Cursor.SetCursor(cursor.texture, cursor.hotspot, CursorMode.Auto);
                    return;
                }
            }
            Cursor.SetCursor(cursorMappings[0].texture, cursorMappings[0].hotspot, CursorMode.Auto);
        }

        [SerializeField] CursorMapping[] cursorMappings = null;


        private bool InteractWithUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                SetCursor(CursorType.None);
                return true;
            }
            else return false;
        }

        private bool InteractWithCombat()
        {
            //Get all object hitted on straight line 
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null || target.tag == "Player") continue;
                SetCursor(CursorType.Combat);
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
                SetCursor(CursorType.Movement);
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