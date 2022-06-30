﻿using UnityEngine;
using System;
using TMPro;

namespace MMORPG.Combat
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;

        private void Awake()
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        }

        private void Update()
        {
            GetComponent<TextMeshProUGUI>().text = String.Format("{0:0}%",health.GetHealthPercent());

        }


    }

}