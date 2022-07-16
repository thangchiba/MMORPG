using System.Collections;
using System.Collections.Generic;
using MMORPG.Stats;
using UnityEngine;
using UnityEngine.Events;

namespace MMORPG.Combat
{
    public class BoomEffect : MonoBehaviour
    {
        [SerializeField] UnityEvent onSpawn;
        public void Start()
        {
            onSpawn.Invoke();
        }
    }
}