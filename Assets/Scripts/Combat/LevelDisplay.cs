using UnityEngine;
using System;
using TMPro;
using MMORPG.Stats;

namespace MMORPG.Combat
{
    public class LevelDisplay : MonoBehaviour
    {               
        LevelControl levelControl;

        private void Awake()
        {
            levelControl = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelControl>();
        }

        private void Update()
        {
            GetComponent<TextMeshProUGUI>().text = String.Format("{0}",levelControl.GetLevel());

        }
    }

}