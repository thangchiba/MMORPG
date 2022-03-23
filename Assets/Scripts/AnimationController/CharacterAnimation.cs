using System.Collections;
using System.Collections.Generic;
using MMORPG.Combat;
using UnityEngine;

namespace MMORPG.Combat
{
    public class CharacterAnimation : MonoBehaviour
    {
        public void Damage()
        {
            GetComponentInParent<Fight>().Damage();
        }

        public void Died()
        {
            print("Died Event");
            GetComponent<Animator>().ResetTrigger("death");
        }
    }
}
