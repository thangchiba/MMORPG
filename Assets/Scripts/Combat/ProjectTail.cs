using System.Collections;
using System.Collections.Generic;
using MMORPG.Stats;
using UnityEngine;
using UnityEngine.Events;

namespace MMORPG.Combat
{
    public class ProjectTail : MonoBehaviour
    {
        [SerializeField] UnityEvent onSpawn;
        [SerializeField] UnityEvent onHit;
        [SerializeField] GameObject BoomEffect = null;
        [SerializeField] float destroyAfterSeconds = 5f;
        [SerializeField] bool destroyAfterHitted = true;
        Fight fight = null;
        CombatTarget combatTarget = null;
        float speed;
        bool isHoming;
        bool isHitted = false;
        public void SpawnProjectTail(Fight fight, float speed, bool isHoming)
        {
            Destroy(gameObject, destroyAfterSeconds);
            this.fight = fight;
            this.combatTarget = fight.CombatTarget;
            this.speed = speed;
            this.isHoming = isHoming;
            transform.LookAt(GetAimLocation());
            StartCoroutine(ArrowMoveToTarget());
            if (onSpawn != null) onSpawn.Invoke();
        }

        IEnumerator ArrowMoveToTarget()
        {
            while (true)
            {
                if (isHitted) { transform.position = GetAimLocation(); } 
                if (isHoming) transform.LookAt(GetAimLocation());
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                yield return null;
            }
        }

        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetCapsule = combatTarget.GetComponent<CapsuleCollider>();
            if (targetCapsule == null)
            {
                return combatTarget.transform.position;
            }
            return combatTarget.transform.position + Vector3.up * targetCapsule.height / 2;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Fight>() == fight) return;

            isHitted = true;
            float damage = fight.GetComponent<BaseStats>().GetStat(Stat.AttackDamage);
            other.GetComponent<Health>().TakeDamage(fight, damage);
            if (destroyAfterHitted) { Destroy(gameObject); }
            if (BoomEffect != null)
            {
                Instantiate(BoomEffect, other.transform);
            }
            if (onHit != null) onHit.Invoke();
        }

    }
}