using System.Collections;
using System.Collections.Generic;
using MMORPG.Control;
using UnityEngine;

namespace MMORPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        Animator animator;
        CombatTarget combatTarget;
        private void Start()
        {
            animator = gameObject.GetComponentInChildren<Animator>();
            combatTarget = GetComponent<CombatTarget>();
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            Debug.Log("HP : " + health);
            if (health == 0)
            {
                Death();
            }
        }

        public void Death()
        {
            combatTarget.Death();
            Debug.Log(gameObject.name + " Be Killed!!!");
            animator.SetTrigger("death");
        }
    }
}