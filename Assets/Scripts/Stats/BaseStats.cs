using UnityEngine;
using System.Collections;
using System;

namespace MMORPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField][Range(1, 100)] int level = 1;
        [SerializeField] CharacterClass characterClass;
        Progression progression;
        [SerializeField] int experience = 10;
        [SerializeField] int experienceReward = 10;

        private void Start()
        {
            progression = Resources.Load<Progression>
                ("Progression/" + System.Enum.GetName(typeof(CharacterClass), characterClass));
        }

        public float GetHealth()
        {
            return progression.GetHealth(level);
        }

        public int GetLevel()
        {
            return level;
        }
        public void UpExperience(int receiveExperience)
        {
            int currentLevel = level;
            experience += receiveExperience;
            level = progression.GetLevel(experience);
            if (level > currentLevel) LevelUp(level);
        }

        private void LevelUp(int level)
        {
            Debug.Log("Up level to " +level);
        }

        public int GetExperience()
        {
            return experience;
        }

        public int GetExperienceReward()
        {
            return experienceReward;
        }
    }

}