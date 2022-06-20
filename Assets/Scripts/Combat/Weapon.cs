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

        public void Spawn(Transform leftHandTransform, Transform rightHandTransform, Animator animator)
        {
            Transform handTransform = rightHandTransform;
            if (hand == Hand.Left) handTransform = leftHandTransform;
            if (weaponPrefab!=null)
            Instantiate(weaponPrefab, handTransform);
            if(animatorOverride!=null)
            animator.runtimeAnimatorController = animatorOverride;
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