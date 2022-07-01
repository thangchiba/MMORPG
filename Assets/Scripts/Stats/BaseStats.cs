using UnityEngine;
using System.Collections;

namespace MMORPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField][Range(1, 100)] int level = 1;
        [SerializeField] CharacterClass characterClass;
        Progression progression;
        [SerializeField] int experience = 10;

        private void Start()
        {
            progression = Resources.Load<Progression>
                ("Progression/" + System.Enum.GetName(typeof(CharacterClass), characterClass));
        }

        public float GetHealth()
        {
            return progression.GetHealth(level);
        }

        public void UpExperience(int receiveExperience)
        {
            experience += receiveExperience;
            level = progression.GetLevel(experience);
        }

        public int GetExperience()
        {
            return experience;
        }
    }

}