using UnityEngine;
using System.Collections;

namespace MMORPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField][Range(1, 100)] int level = 1;
        [SerializeField] CharacterClass characterClass;
    }

}