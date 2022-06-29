using UnityEngine;
using System.Collections;

namespace MMORPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1, 100)]
        [SerializeField] int level = 1;
        [SerializeField] CharacterClass characterClass;
    }

}