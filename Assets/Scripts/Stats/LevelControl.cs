using UnityEngine;
using System.Collections;
using System;

namespace MMORPG.Stats
{
    public class LevelControl : MonoBehaviour
    {
        [SerializeField] int level = 1;
        [SerializeField] int experience = 0;
        [SerializeField] GameObject levelUpEffect;
        public event Action onUpExperience;
        public event Action onUpLevel;

        private void Awake()
        {
            levelUpEffect = Resources.Load<GameObject>("Effects/LevelUp");
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
            if (onUpExperience != null) onUpExperience();
        }

        public int GetLevel()
        {
            return level;
        }
        private void LevelUp(int level)
        {
            Instantiate(levelUpEffect, transform);
            if (onUpLevel != null) onUpLevel();
        }

        public int GetExperience()
        {
            return experience;
        }
    }

}