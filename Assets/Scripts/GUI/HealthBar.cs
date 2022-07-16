using UnityEngine;
using System.Collections;
using MMORPG.Combat;

namespace MMORPG.GUI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] Health health = null;
        [SerializeField] RectTransform healthBar = null;

        private void Start()
        {
            health.onDeath += OnDeath;
        }

        public void OnDeath()
        {
            gameObject.SetActive(false);
        }

        public void Update()
        {
            healthBar.localScale = new Vector3(health.GetHealthPercent()/100f, 1, 1);
        }
    }
}