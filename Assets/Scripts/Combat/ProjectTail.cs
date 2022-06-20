using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.Combat
{
    public class ProjectTail : MonoBehaviour
    {
        Transform target;
        float speed;
        float attackDamage;
        public float Speed { get => speed; set => speed = value; }
        public Transform Target { get => target; set => target = value; }
        public float AttackDamage { get => attackDamage; set => attackDamage = value; }

        // Update is called once per frame
        void Update()
        {
            if (target == null) return;
            transform.LookAt(GetAimLocation());
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
            if (targetCapsule == null)
            {
                return target.transform.position;
            }
            return target.transform.position + Vector3.up * targetCapsule.height / 2;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player") return;
            try
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(attackDamage);
            }
            finally
            {
                Destroy(gameObject);
            }
        }

    }
}