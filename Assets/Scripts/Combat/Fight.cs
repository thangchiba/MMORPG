using System;
using System.Collections;
using MMORPG.Move;
using UnityEngine;

namespace MMORPG.Combat
{
    public class Fight : MonoBehaviour
    {
        [SerializeField] float attackRange = 5f;
        GameObject target;
        bool attackMode = false;
        bool isAttacking = false;
        bool isChasing = false;
        public void SetTarget(GameObject target)
        {
            attackMode = false;
            this.target = target;
            if (target.tag == "Enemy" || target.tag == "Minion")
            {
                attackMode = true;
                StartCoroutine("Attack");
            }
        }
        private void ChaseTarget()
        {
            if(!isChasing)
            GetComponent<Mover>().MoveToPoint(target.gameObject.transform.position);
            isChasing = true;
        }

        IEnumerator Attack()
        {
            while (attackMode)
            {
                if (Vector3.Distance(target.gameObject.transform.position, gameObject.transform.position) < attackRange)
                {
                    isAttacking = true;
                    isChasing = false;
                    Debug.Log("Attacking" + Time.time);
                }
                else
                {
                    isAttacking = false;
                    ChaseTarget();
                }
                yield return new WaitForSeconds(1);
            }
        }
    }
}