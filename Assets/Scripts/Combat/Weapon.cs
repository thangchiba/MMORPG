using System;
using UnityEngine;

namespace MMORPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Create New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] GameObject weaponPrefab = null;
        [SerializeField] float attackRange = 1f;
        [SerializeField][Range(5, 150)]float attackSpeed = 20f;
        [SerializeField] float attackDamage = 10f;
        [SerializeField] Hand hand;
        [SerializeField] GameObject projectTailPrefab = null;
        [SerializeField] float projectTailSpeed = 10;
        Transform handTransform;

        public void Spawn(Transform leftHandTransform, Transform rightHandTransform, Animator animator)
        {
            handTransform = GetHandTransform(leftHandTransform, rightHandTransform);
            if (weaponPrefab != null)
                Instantiate(weaponPrefab, handTransform);
            if (animatorOverride != null)
                animator.runtimeAnimatorController = animatorOverride;
        }

        public void SpawnProjectTail(Transform target)
        {
            GameObject projectTail = Instantiate(projectTailPrefab, handTransform.position,Quaternion.identity);
            projectTail.GetComponent<ProjectTail>().Target = target;
            projectTail.GetComponent<ProjectTail>().Speed = projectTailSpeed;
            projectTail.GetComponent<ProjectTail>().AttackDamage = attackDamage;
        }
        

        private Transform GetHandTransform(Transform leftHandTransform, Transform rightHandTransform)
        {
            Transform handTransform = rightHandTransform;
            if (hand == Hand.Left) handTransform = leftHandTransform;
            return handTransform;
        }
        public float AttackRange { get => attackRange; }
        public float AttackSpeed { get => attackSpeed; }
        public float AttackDamage { get => attackDamage; }
    }

    enum Hand
    {
        Right,
        Left,
    }
}