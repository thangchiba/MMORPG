using System;
using MMORPG.Stats;
using UnityEngine;

namespace MMORPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Create New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] GameObject weaponPrefab = null;
        [SerializeField] Hand hand;
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] float attackDamage = 10f;
        [SerializeField] float attackRange = 1f;
        [SerializeField][Range(5, 150)] float attackSpeed = 20f;
        [SerializeField][Range(0, 100)] float buffDamagePercent = 0f;
        public float AttackRange { get => attackRange; }
        public float AttackSpeed { get => attackSpeed; }
        public float AttackDamage { get => attackDamage; }
        public float BuffDamagePercent { get => buffDamagePercent; }
        [SerializeField] GameObject projectTailPrefab = null;
        [SerializeField] float projectTailSpeed = 10;
        [SerializeField] bool projectTailIsHoming = false;

        public void Spawn(Transform leftHandTransform, Transform rightHandTransform, Animator animator)
        {
            Transform handTransform = GetHandTransform(leftHandTransform, rightHandTransform);
            if (weaponPrefab == null) return;
                Instantiate(weaponPrefab, handTransform);
            if (animatorOverride == null) return;
                animator.runtimeAnimatorController = animatorOverride;
        }

        public void SpawnProjectTail(Fight fight,Transform leftHandTransform, Transform rightHandTransform)
        {
            Transform handTransform = GetHandTransform(leftHandTransform, rightHandTransform);
            GameObject projectTail = Instantiate(projectTailPrefab, handTransform.position, Quaternion.identity);
            projectTail.GetComponent<ProjectTail>().SpawnProjectTail(fight, projectTailSpeed, projectTailIsHoming);
        }

        private Transform GetHandTransform(Transform leftHandTransform, Transform rightHandTransform)
        {
            Transform handTransform = rightHandTransform;
            if (hand == Hand.Left) handTransform = leftHandTransform;
            return handTransform;
        }
    }

    enum Hand
    {
        Right,
        Left,
    }

    class WeaponProgress
    {
        public Stat stat;
        public float value;
    }
}