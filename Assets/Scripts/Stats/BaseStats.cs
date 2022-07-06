using UnityEngine;
using System.Collections;
using System;

namespace MMORPG.Stats
{
    [RequireComponent(typeof(LevelControl))]
    public class BaseStats : MonoBehaviour
    {
        [SerializeField] CharacterClass characterClass;
        Progression progression;
        LevelControl levelControl;
        private void Awake()
        {
            progression = Resources.Load<Progression>
                ("Progression/" + System.Enum.GetName(typeof(CharacterClass), characterClass));
            progression.BuildProgress();
            levelControl = GetComponent<LevelControl>();
        }

        public float GetHealth()
        {
            return progression.GetStat(Stat.Health,levelControl.GetLevel());
        }

        public int GetExperienceReward()
        {
            return (int)progression.GetStat(Stat.ExperienceReward, levelControl.GetLevel());
        }

        public float GetAttackDamage()
        {
            return progression.GetStat(Stat.AttackDamage, levelControl.GetLevel());
        }

        public float GetAttackSpeed()
        {
            return progression.GetStat(Stat.AttackSpeed, levelControl.GetLevel());
        }

        public float GetAttackRange()
        {
            return progression.GetStat(Stat.AttackRange, levelControl.GetLevel());
        }
    }

}