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
        private void Start()
        {
            fight = GetComponentInParent<Fight>();
            animator = GetComponent<Animator>();
        }
        public void Damage()
        {
            fight.Damage();
        }

        public void Died()
        {
            animator.ResetTrigger("death");
        }
    }
}
