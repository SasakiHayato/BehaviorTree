namespace BehaviorTree
{
    public abstract class ExecuteBase
    {
        public bool IsExecute => Execute();

        public abstract void SetUp(UnityEngine.GameObject user);

        protected abstract bool Execute();
    }
}