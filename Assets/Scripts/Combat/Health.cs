using System;
using MMORPG.Stats;
using UnityEngine;
using UnityEngine.Events;

namespace MMORPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        Animator animator;
        CombatTarget combatTarget;
        LevelControl levelControl;
        [SerializeField] UnityEvent<float> takeDamageEvent;

        private void Awake()
        {
            animator = gameObject.GetComponentInChildren<Animator>();
            combatTarget = GetComponent<CombatTarget>();
            levelControl = GetComponent<LevelControl>();
        }

        private void Start()
        {
            health = GetComponent<BaseStats>().GetStat(Stat.Health);
            levelControl.onUpLevel += OnUpLevel;
        }

        public Action onUpdateHealth;
        void UpdateHealth(float newHealth)
        {
            health = newHealth;
            if (onUpdateHealth != null) onUpdateHealth();
        }


        public float TakeDamage(Fight instigator, float damage)
        {
            takeDamageEvent.Invoke(damage);
            UpdateHealth(Mathf.Max(health - damage, 0));
            if (health <= 0)
            {
                Death(instigator);
            }
            if (onUpdateHealth != null) onUpdateHealth();
            return health;
        }

        public void Death(Fight instigator)
        {
            combatTarget.Death();
            Debug.Log(gameObject.name + " Be Killed By " + instigator.gameObject.name);
            int experienceReward = (int)gameObject.GetComponent<BaseStats>().GetStat(Stat.ExperienceReward);
            instigator.GetComponent<LevelControl>().UpExperience(experienceReward);
            animator.SetTrigger("death");
        }

        void OnUpLevel()
        {
            UpdateHealth(GetComponent<BaseStats>().GetStat(Stat.Health));
        }

        public float GetHealthPercent()
        {
            return (health / GetComponent<BaseStats>().GetStat(Stat.Health)) * 100;
        }
    }
}