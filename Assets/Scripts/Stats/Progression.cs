using UnityEngine;
using System;
using System.Collections.Generic;

namespace MMORPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject
    {
        [SerializeField] CharacterClass characterClass;
        [SerializeField] float health;
        [SerializeField] int experienceReward;
        [SerializeField] float attackDamage;
        [SerializeField] float attackSpeed;
        [SerializeField] float attackRange;
        Dictionary<Stat, float[]> progress = null;

        public float GetStat(Stat stat,int level)
        {
            return progress[stat][level];
        }

        public void BuildProgress()
        {
            progress = new Dictionary<Stat, float[]>();
            progress[Stat.Health]=  CalcData(health);
            progress[Stat.ExperienceReward] = CalcData(experienceReward);
            progress[Stat.AttackDamage] = CalcData(attackDamage);
            progress[Stat.AttackSpeed] = CalcData(attackSpeed);
            progress[Stat.AttackRange] = CalcData(attackRange);
        }

        float[] CalcData(float baseValue)
        {
            float[] result = new float[200];
            for (int i = 0; i < 200; i++)
            {
                result[i] = baseValue + (i * (baseValue / 20));
            }
            return result;
        }

        //public float GetHealth(int level)
        //{
        //    try
        //    {
        //        return health[level - 1];
        //    }
        //    catch
        //    {
        //        return 60 * level;
        //    }
        //}

        //public int GetExperienceReward(int level)
        //{
        //    try
        //    {
        //        return experienceReward[level - 1];
        //    }
        //    catch
        //    {
        //        return 10 * level;
        //    }
        //}

        //public float GetAttackDamage(int attackDamage, int level)
        //{
        //    return attackDamage + (level * 1f);
        //}

        //public float GetAttackRange(int attackRange, int level)
        //{
        //    return attackRange + (level * 0.1f);
        //}

        //public float GetAttackSpeed(int attackSpeed, int level)
        //{
        //    return attackSpeed + (level / 2f);
        //}


    }
}