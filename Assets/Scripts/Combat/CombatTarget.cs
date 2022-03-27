using MMORPG.Control;
using MMORPG.Core;
using MMORPG.Movement;
using UnityEngine;

namespace MMORPG.Combat
{
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour
    {
        public bool isDead = false;
        public void Death()
        {
            isDead = true;
            GetComponent<Fight>().enabled = false;
            GetComponent<Mover>().enabled = false;
            if (tag == "Player") { GetComponent<PlayerController>().disableControl = true; }
            if (tag == "Minion")
            {
                GetComponent<ArtificialIntelligence>().enabled = false;
                GetComponent<Patrol>().Cancel();
            }
            //Let can't click the died element
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}