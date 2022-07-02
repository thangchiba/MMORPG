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
        private void Start()
        {
            progression = Resources.Load<Progression>
                ("Progression/" + System.Enum.GetName(typeof(CharacterClass), characterClass));
            levelControl = GetComponent<LevelControl>();
            levelControl.SetStartLevel(progression.GetStartLevel());
        }

        public float GetHealth()
        {
            return progression.GetHealth(levelControl.GetLevel());
        }

        public int GetExperienceReward()
        {
            return progression.GetExperienceReward(levelControl.GetLevel());
        }
    }

}