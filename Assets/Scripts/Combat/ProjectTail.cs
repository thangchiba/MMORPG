using System.Collections;
using System.Collections.Generic;
using MMORPG.Stats;
using UnityEngine;

namespace MMORPG.Combat
{
    public class ProjectTail : MonoBehaviour
    {
        [SerializeField] GameObject BoomEffect = null;
        Fight fight = null;
        CombatTarget combatTarget = null;
        float speed;
        bool isHoming;
        public void SpawnProjectTail(Fight fight, float speed, bool isHoming)
        {
            Destroy(gameObject, 5f);
            this.fight = fight;
            this.combatTarget = fight.CombatTarget;
            this.speed = speed;
            this.isHoming = isHoming;
            transform.LookAt(GetAimLocation());
            StartCoroutine(ArrowMoveToTarget());
        }

        IEnumerator ArrowMoveToTarget()
        {
            while (true)
            {
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
            float damage = fight.GetComponent<BaseStats>().GetStat(Stat.AttackDamage);
            if (other.GetComponent<Fight>() == fight) return;
            other.GetComponent<Health>().TakeDamage(fight,damage);
            Destroy(gameObject);
            if (BoomEffect != null)
            {
                Instantiate(BoomEffect, other.transform);
            }
        }

    }
}