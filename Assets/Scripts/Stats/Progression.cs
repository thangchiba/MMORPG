using UnityEngine;
using System;

namespace MMORPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject
    {
        [SerializeField] CharacterProgression[] characterProgresses = null;

        [Serializable]
        class CharacterProgression
        {
            [SerializeField] CharacterClass characterClass;
            [SerializeField] float[] health = 0;
        }
    }
}