using UnityEngine;
using System;

namespace MMORPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject
    {
        [SerializeField] CharacterClass characterClass;
        [SerializeField] float[] health;
        [SerializeField][Range(1, 100)] int startLevel = 1;
        [SerializeField] int[] experienceReward;

        public float GetHealth(int level)
        {
            try
            {
                return health[level - 1];
            }
            catch
            {
                return 60 * level;
            }
        }

        public int GetExperienceReward(int level)
        {
            try
            {
                return experienceReward[level - 1];
            }
            catch
            {
                return 10 * level;
            }
        }

        public int GetStartLevel()
        {
            return startLevel;
        }

    }
}