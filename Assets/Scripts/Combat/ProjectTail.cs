using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.Combat
{
    public class ProjectTail : MonoBehaviour
    {
        Fight fight = null;
        CombatTarget combatTarget = null;
        float speed;
        public void SpawnProjectTail(Fight fight,float speed)
        {
            Destroy(gameObject, 5f);
            this.fight = fight;
            this.combatTarget = fight.CombatTarget;
            this.speed = speed;
            transform.LookAt(GetAimLocation());
            StartCoroutine(ArrowMoveToTarget());
        }

        IEnumerator ArrowMoveToTarget()
        {
            while (true)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
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
            combatTarget.GetComponent<Health>().TakeDamage(fight.AttackDamage);
            Destroy(gameObject);
        }

    }
}