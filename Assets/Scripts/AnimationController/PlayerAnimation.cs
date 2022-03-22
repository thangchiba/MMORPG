using System.Collections;
using System.Collections.Generic;
using MMORPG.Combat;
using UnityEngine;

namespace MMORPG.Combat
{
    public class PlayerAnimation : MonoBehaviour
    {
        public void Damage()
        {
            GetComponentInParent<Fight>().Damage();
        }
    }
}
