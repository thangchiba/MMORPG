using UnityEngine;
using System.Collections;
using System;

namespace MMORPG.Stats
{
    public class LevelControl : MonoBehaviour
    {
        [SerializeField] int level = 1;
        [SerializeField] int experience = 0;

        public void SetStartLevel(int startLevel)
        {
            level = startLevel;
        }

        public int CalcLevel(int experience)
        {
            return experience / 10;
        }
        public void UpExperience(int receiveExperience)
        {
            int currentLevel = level;
            experience += receiveExperience;
            level = CalcLevel(experience);
            if (level > currentLevel) LevelUp(level);
        }

        public int GetLevel()
        {
            return level;
        }
        private void LevelUp(int level)
        {
            Debug.Log("Up level to " + level);
        }

        public int GetExperience()
        {
            return experience;
        }
    }

}