namespace MMORPG.Core
{
    /// <summary>
    /// Interface that inherited object will cancel previous action when excute a action
    /// </summary>
    public interface IAction
    {
        void Cancel();
    }
}

