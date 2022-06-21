using UnityEngine;
using MMORPG.Movement;
using MMORPG.Core;
using System;

namespace MMORPG.Combat
{
    public class Fight : MonoBehaviour, IAction
    {
        [SerializeField] float attackRange = 1f;
        [SerializeField][Range(15, 150)] float attackSpeed = 15f;
        [SerializeField] float attackDamage = 5f;
        [SerializeField] Transform rightHandTransform = null;
        [SerializeField] Transform leftHandTransform = null;
        [SerializeField] Weapon defaultWeapon = null;
        Animator animator;
        CombatTarget combatTarget;
        Mover mover;
        ActionScheduler actionScheduler;
        Weapon currentWeapon = null;
        public Weapon CurrentWeapon { get => currentWeapon;}
        public CombatTarget CombatTarget { get => combatTarget; set => combatTarget = value; }
        public float AttackDamage { get => attackDamage; set => attackDamage = value; }

        void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            mover = GetComponent<Mover>();
            actionScheduler = GetComponent<ActionScheduler>();
            EquipWeapon(defaultWeapon);
        }
        private void Update()
        {
            if (combatTarget == null) return;
            if (combatTarget.isDead) { Cancel(); return; }
            if (!GetIsInRange())
            {
                InterruptAttack();
                mover.MoveTo(combatTarget.transform.position);
            }
            else
            {
                mover.Cancel();
                AttackBehaviour();
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (weapon == null) return;
            currentWeapon = weapon;
            weapon.Spawn(leftHandTransform,rightHandTransform, animator);
            attackRange += weapon.AttackRange;
            attackSpeed += weapon.AttackSpeed;
            attackDamage += weapon.AttackDamage;
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, combatTarget.transform.position) < attackRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            actionScheduler.StartAction(this);
            this.combatTarget = combatTarget;
        }

        private void AttackBehaviour()
        {
            gameObject.transform.LookAt(combatTarget.transform);
            animator.SetTrigger("attack");
            animator.SetFloat("attackSpeed", attackSpeed / 100);
        }

        public void Damage()
        {
            combatTarget.GetComponent<Health>().TakeDamage(attackDamage);
        }

        public void Shot()
        {
            currentWeapon.SpawnProjectTail(this,leftHandTransform,rightHandTransform);
        }

        public void Cancel()
        {
            combatTarget = null;
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