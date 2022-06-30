using UnityEngine;
using System;

namespace MMORPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject
    {
       [SerializeField] CharacterClass characterClass;
       [SerializeField] float[] health;

        public float GetHealth(int level)
        {
            return health[level-1];
        }
    }
}