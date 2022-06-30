using UnityEngine;
using System.Collections;

namespace MMORPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField][Range(1, 100)] int level = 1;
        [SerializeField] CharacterClass characterClass;
        [SerializeField] Progression progression;

        private void Start()
        {
            progression = Resources.Load<Progression>
                ("Progression/" + System.Enum.GetName(typeof(CharacterClass), characterClass));
        }

        public float GetHealth()
        {
            return progression.GetHealth(level);
        }
    }

}