using UnityEngine;
using System;
using TMPro;

namespace MMORPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fight fight;

        private void Awake()
        {
            fight = GameObject.FindGameObjectWithTag("Player").GetComponent<Fight>();
        }

        private void Update()
        {
            if(fight.CombatTarget==null)
                GetComponent<TextMeshProUGUI>().text = "NaN";
            else
                GetComponent<TextMeshProUGUI>().text =
                    String.Format("{0:0}%", fight.CombatTarget.GetComponent<Health>().GetHealthPercent());


        }


    }

}