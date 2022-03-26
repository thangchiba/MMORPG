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
        Mover mover;
        ActionScheduler actionScheduler;
        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            mover = GetComponent<Mover>();
            actionScheduler = GetComponent<ActionScheduler>();
        }
        private void Update()
        {
            if (target == null) return;
            if (target.isDead) { Cancel(); return; }
            if (!GetIsInRange())
            {
                mover.MoveTo(target.transform.position);
                InterruptAttack();
            }
            else
            {
                mover.Cancel();
                AttackBehaviour();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < attackRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            actionScheduler.StartAction(this);
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