using System.Collections;
using System.Collections.Generic;
using MMORPG.Combat;
using UnityEngine;

namespace MMORPG.Combat
{
    public class CharacterAnimation : MonoBehaviour
    {
        Fight fight;
        Animator animator;
        private void Awake()
        {
            fight = GetComponentInParent<Fight>();
            animator = GetComponent<Animator>();
        }
        public void Damage()
        {
            fight.Damage();
        }

        public void Shot()
        {
            fight.Shot();
        }

        public void Died()
        {
            animator.ResetTrigger("death");
        }
    }
}
