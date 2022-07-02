using UnityEngine;
using System;
using TMPro;
using MMORPG.Stats;

namespace MMORPG.Combat
{
    public class LevelDisplay : MonoBehaviour
    {
        BaseStats stats;

        private void Awake()
        {
            stats = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseStats>();
        }

        private void Update()
        {
            GetComponent<TextMeshProUGUI>().text = String.Format("{0}",stats.GetLevel());

        }


    }

}