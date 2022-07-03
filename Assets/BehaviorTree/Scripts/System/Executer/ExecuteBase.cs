namespace BehaviorTree
{
    public abstract class ExecuteBase
    {
        public bool IsExecute => BaseExecute();

        public abstract void BaseInit();

        public abstract void BaseSetUp(UnityEngine.GameObject user);

        protected abstract bool BaseExecute();
    }
}