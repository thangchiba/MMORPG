using System;
using System.Collections;
using MMORPG.Move;
using UnityEngine;
using UnityEngine.AI;

namespace MMORPG.Combat
{
    public class Fight : MonoBehaviour
    {
        [SerializeField] int attackRange = 5;
        [SerializeField] int attackSpeed = 100;
        [SerializeField] int huntRange = 30;
        GameObject target;
        bool isAttacking = false;
        Mover mover;
        private void Start()
        {
            mover = GetComponent<Mover>();
        }

        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        private void Update()
        {
            if (target == null) return;
            bool isInRangeAttack = Vector3.Distance(target.gameObject.transform.position, gameObject.transform.position) < attackRange;
            if (isInRangeAttack)
            {
                mover.StopMove();
                if (!isAttacking)
                {
                    isAttacking = true;
                    StartCoroutine("Attack");
                }
            }
            else if(Vector3.Distance(target.gameObject.transform.position, gameObject.transform.position) > huntRange)
            {
                CancelAttack();
                target = null;
            }
            else
            {
                CancelAttack();
                mover.MoveToPoint(target.gameObject.transform.position);
            }
        }

        IEnumerator Attack()
        {
            while (isAttacking)
            {
                Debug.Log("Attacking" + Time.time);
                yield return new WaitForSeconds(100 / attackSpeed);
            }
        }

        private void CancelAttack()
        {
            isAttacking = false;
            StopCoroutine("Attack");
        }
    }
}