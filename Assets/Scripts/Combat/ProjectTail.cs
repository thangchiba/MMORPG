using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.Combat
{
    public class ProjectTail : MonoBehaviour
    {
        Fight fight;
        float speed;
        public void SpawnProjectTail(Fight fight,float speed)
        {
            Debug.Log("vao trong projecttail");
            this.fight = fight;
            this.speed = speed;
        }

        // Update is called once per frame
        void Update()
        {
            if (fight.CombatTarget == null) return;
            transform.LookAt(GetAimLocation());
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetCapsule = fight.CombatTarget.GetComponent<CapsuleCollider>();
            if (targetCapsule == null)
            {
                return fight.CombatTarget.transform.position;
            }
            return fight.CombatTarget.transform.position + Vector3.up * targetCapsule.height / 2;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Fight>() == fight) return;
            //other.gameObject.GetComponent<Health>().TakeDamage(attackDamage);
            fight.Damage();
            Destroy(gameObject);
        }

    }
}