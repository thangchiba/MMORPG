using UnityEngine;
using System;
using TMPro;
using MMORPG.Stats;

namespace MMORPG.Combat
{
    public class ExperienceDisplay : MonoBehaviour
    {
        LevelControl levelControl;

        private void Awake()
        {
            levelControl = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelControl>();
            UpdateExperience();
            levelControl.onUpExperience += UpdateExperience;
        }

        private void UpdateExperience()
        {
            GetComponent<TextMeshProUGUI>().text = String.Format("{0}",levelControl.GetExperience());
        }
    }

}