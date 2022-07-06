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

        public float GetStat(Stat stat) {
            return progression.GetStat(stat, levelControl.GetLevel());
        }
    }

}