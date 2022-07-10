using MMORPG.Control;
using MMORPG.Core;
using MMORPG.Movement;
using UnityEngine;

namespace MMORPG.Combat
{
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour,IRaycastable
    {
        public bool isDead = false;
        Fight player;
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Fight>();
        }

        public void Death()
        {
            isDead = true;
            GetComponent<Fight>().enabled = false;
            GetComponent<Mover>().enabled = false;
            if (tag == "Player") { GetComponent<PlayerController>().enabled = false; }
            if (tag == "Minion")
            {
                GetComponent<ArtificialIntelligence>().enabled = false;
                GetComponent<Patrol>().Cancel();
            }
            //Let can't click the died element
            GetComponent<CapsuleCollider>().enabled = false;
        }

        public CursorType GetCursorType()
        {
            return CursorType.Combat;
        }

        public bool HandleRaycast()
        {
            if (tag == "Player") return false;
            //if (this == player.CombatTarget) return false;
            if (Input.GetMouseButtonDown(0))
            {
                player.Attack(this);
            }
            return true;
        }
    }
}