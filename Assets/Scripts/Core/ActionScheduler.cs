using UnityEngine;

namespace MMORPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        /// <summary>
        /// Dependence Injection, An action when excute will cancel previous action
        /// </summary>
        /// <param name="action"></param>
        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                Debug.Log("Change Action ");
                currentAction.Cancel();
            }
            currentAction = action;
        }
    }
}