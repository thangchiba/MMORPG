using UnityEngine;
using System;
using TMPro;

namespace MMORPG.Combat
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;

        private void Start()
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            UpdateHealth();
            health.onTakeDamage += UpdateHealth;
        }

        private void UpdateHealth()
        {
            GetComponent<TextMeshProUGUI>().text = String.Format("{0:0}%",health.GetHealthPercent());

        }


    }

}