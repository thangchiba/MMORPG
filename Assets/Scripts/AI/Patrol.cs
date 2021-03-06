using System;
using System.Collections;
using System.Collections.Generic;
using MMORPG.Combat;
using MMORPG.Core;
using MMORPG.Movement;
using UnityEngine;

namespace MMORPG.Combat
{
    public class Patrol : MonoBehaviour, IAction
    {
        [SerializeField] GameObject patrolPath;
        ActionScheduler actionScheduler;
        Mover mover;
        CombatTarget combatTarget;
        bool patrolStatus = false;
        int patrolCurrentIndex = 0;
        void Awake()
        {
            actionScheduler = GetComponent<ActionScheduler>();
            mover = GetComponent<Mover>();
            combatTarget = GetComponent<CombatTarget>();
        }

        public void StartPatrolAction()
        {
            actionScheduler.StartAction(this);
            if (!patrolStatus) { StartCoroutine("PatrolBehaviour"); }
        }

        IEnumerator PatrolBehaviour()
        {
            patrolStatus = true;
            while (!combatTarget.isDead)
            {
                //Patrolling position will loop 0-...
                int nextPointIndex = patrolCurrentIndex % patrolPath.transform.childCount;
                Vector3 nextPoint = patrolPath.transform.GetChild(nextPointIndex).position;
                mover.MoveTo(nextPoint);
                patrolCurrentIndex++;
                yield return new WaitForSeconds(5f);
            }
            Cancel();
        }

        public void Cancel()
        {
            patrolStatus = false;
            StopCoroutine(PatrolBehaviour());
            mover.Cancel();
        }

        private void OnDrawGizmos()
        {
            mover = GetComponentInParent<Mover>();
            for (int a = 0; a < transform.childCount; a++)
            {
                Vector3 currentPoint = transform.GetChild(a).position;
                int nextPointIndex = GetNextPointIndex(a);
                Vector3 nextPoint = transform.GetChild(nextPointIndex).position;
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(currentPoint, nextPoint);
            }
        }

        private int GetNextPointIndex(int currentIndex)
        {
            if (currentIndex != transform.childCount - 1) { return currentIndex + 1; }
            else return 0;
        }
    }
}
