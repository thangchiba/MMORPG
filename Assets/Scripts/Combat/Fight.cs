using UnityEngine;
using MMORPG.Movement;
using MMORPG.Core;
using System;

namespace MMORPG.Combat
{
    public class Fight : MonoBehaviour, IAction
    {
        [SerializeField] float attackRange = 3f;
        [SerializeField][Range(50, 150)] float attackSpeed = 50f;
        [SerializeField] float attackDamage = 5f;
        Animator animator;
        CombatTarget target;

        void Start()
        {
            animator = gameObject.GetComponentInChildren<Animator>();
        }
        private void Update()
        {
            if (target == null) return;
            if (target.isDead) { Cancel(); return; }
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
                InterruptAttack();
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < attackRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget;
        }

        private void AttackBehaviour()
        {
            gameObject.transform.LookAt(target.transform);
            animator.SetTrigger("attack");
            animator.SetFloat("attackSpeed", attackSpeed / 100);
        }

        public void Damage()
        {
            target.GetComponent<Health>().TakeDamage(attackDamage);
        }

        public void Cancel()
        {
            target = null;
            animator.ResetTrigger("attack");
            animator.SetTrigger("stopAttack");
        }

        public void InterruptAttack()
        {
            animator.ResetTrigger("attack");
            animator.SetTrigger("stopAttack");
        }
    }
}