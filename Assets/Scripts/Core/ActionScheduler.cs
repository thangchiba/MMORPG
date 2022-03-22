using UnityEngine;

namespace MMORPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

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