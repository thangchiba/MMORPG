using UnityEngine;
using MMORPG.Movement;
using MMORPG.Core;
using System;
using MMORPG.Stats;
using System.Collections.Generic;

namespace MMORPG.Combat
{
    public class Fight : MonoBehaviour, IAction, IModifyStat
    {
        [SerializeField] Transform rightHandTransform = null;
        [SerializeField] Transform leftHandTransform = null;
        [SerializeField] String defaultWeaponName = "Unarmed";
        [SerializeField] float damage = 0f;
        Animator animator;
        CombatTarget combatTarget;
        Mover mover;
        ActionScheduler actionScheduler;
        Weapon currentWeapon = null;
        public Weapon CurrentWeapon { get => currentWeapon; }
        public CombatTarget CombatTarget { get => combatTarget; set => combatTarget = value; }

        void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            mover = GetComponent<Mover>();
            actionScheduler = GetComponent<ActionScheduler>();
            var weapon = Resources.Load<Weapon>("Weapons/" + defaultWeaponName);
            EquipWeapon(weapon);
            damage = GetComponent<BaseStats>().GetStat(Stat.AttackDamage);
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
            DestroyOldWeapon();
            currentWeapon = weapon;
            weapon.Spawn(leftHandTransform, rightHandTransform, animator);
        }

        private void DestroyOldWeapon()
        {
            foreach (Transform child in rightHandTransform)
            {
                GameObject.Destroy(child.gameObject);
            }
            foreach (Transform child in leftHandTransform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        private bool GetIsInRange()
        {
            float attackRange = GetComponent<BaseStats>().GetStat(Stat.AttackRange);
            return Vector3.Distance(transform.position, combatTarget.transform.position) < attackRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            actionScheduler.StartAction(this);
            this.combatTarget = combatTarget;
        }

        private void AttackBehaviour()
        {
            float attackSpeed = GetComponent<BaseStats>().GetStat(Stat.AttackSpeed);
            gameObject.transform.LookAt(combatTarget.transform);
            animator.SetTrigger("attack");
            animator.SetFloat("attackSpeed", attackSpeed / 100);
        }

        public void Damage()
        {
            float damage = GetComponent<BaseStats>().GetStat(Stat.AttackDamage);
            combatTarget.GetComponent<Health>().TakeDamage(this, damage);
        }

        public void Shot()
        {
            currentWeapon.SpawnProjectTail(this, leftHandTransform, rightHandTransform);
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

        public IEnumerable<float> AddStraight(Stat stat)
        {
            if (stat == Stat.AttackDamage) yield return currentWeapon.AttackDamage;
            if (stat == Stat.AttackRange) yield return currentWeapon.AttackRange;
            if (stat == Stat.AttackSpeed) yield return currentWeapon.AttackSpeed;
        }

        public IEnumerable<float> AddPercent(Stat stat)
        {
            if (stat == Stat.AttackDamage) yield return currentWeapon.BuffDamagePercent;
        }
    }
}