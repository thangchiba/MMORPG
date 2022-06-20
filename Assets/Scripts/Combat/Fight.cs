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
        CombatTarget target;
        Mover mover;
        ActionScheduler actionScheduler;
        Weapon currentWeapon = null;
        public Weapon CurrentWeapon { get => currentWeapon;}
        public CombatTarget Target { get => target; }

        void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            mover = GetComponent<Mover>();
            actionScheduler = GetComponent<ActionScheduler>();
            EquipWeapon(defaultWeapon);
        }
        private void Update()
        {
            if (target == null) return;
            if (target.isDead) { Cancel(); return; }
            if (!GetIsInRange())
            {
                InterruptAttack();
                mover.MoveTo(target.transform.position);
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
            print(CurrentWeapon);
            //Equip weapon on hand
            //Instantiate(weapon, handTransform);
            weapon.Spawn(leftHandTransform,rightHandTransform, animator);
            attackRange += weapon.AttackRange;
            attackSpeed += weapon.AttackSpeed;
            attackDamage += weapon.AttackDamage;
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