using UnityEngine;
using System.Collections;
using System.Linq;

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

        public float GetStat(Stat stat)
        {
            return progression.GetStat(stat, levelControl.GetLevel()) + CalcModify(stat);
        }


        public float CalcModify(Stat stat)
        {
            float result = 0;
            foreach (IModifyStat modifies in GetComponents<IModifyStat>())
            {
                foreach (float value in modifies.AddStraight(stat))
                {
                    result += value;
                }
            }
            if(gameObject.tag=="Player" && stat == Stat.AttackDamage)
            Debug.Log("Vao tinh toan" + result);
            return result;

        }

    }

}