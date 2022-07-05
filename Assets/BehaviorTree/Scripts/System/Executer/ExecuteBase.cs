namespace BehaviorTree
{
    /// <summary>
    /// Action��Condition���쐬����ۂ̊��N���X
    /// </summary>
    public abstract class ExecuteBase
    {
        public bool IsExecute => BaseExecute();

        public abstract void BaseInit();

        public abstract void BaseSetUp(UnityEngine.GameObject user);

        protected abstract bool BaseExecute();
    }
}