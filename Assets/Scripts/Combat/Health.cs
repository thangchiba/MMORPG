using MMORPG.Stats;
using UnityEngine;

namespace MMORPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        Animator animator;
        CombatTarget combatTarget;
        private void Start()
        {
            animator = gameObject.GetComponentInChildren<Animator>();
            combatTarget = GetComponent<CombatTarget>();
            health = GetComponent<BaseStats>().GetHealth();
        }

        public float TakeDamage(Fight instigator,float damage)
        {
            health = Mathf.Max(health - damage, 0);
            //Debug.Log("HP : " + health);
            if (health == 0)
            {
                Death(instigator);
            }
            return health;
        }

        public void Death(Fight instigator)
        {
            combatTarget.Death();
            Debug.Log(gameObject.name + " Be Killed By "+instigator.gameObject.name);
            int experienceReward = gameObject.GetComponent<BaseStats>().GetExperienceReward();
            instigator.GetComponent<LevelControl>().UpExperience(experienceReward);
            animator.SetTrigger("death");
        }

        public float GetHealthPercent()
        {
            return (health / GetComponent<BaseStats>().GetHealth()) * 100; 
        }
    }
}