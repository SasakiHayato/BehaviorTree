using UnityEngine;

namespace BehaviorTree.Execute
{
    [System.Serializable]
    public abstract class Action : ExecuteBase
    {
        public override void BaseSetUp(GameObject user) => SetUp(user);

        public override void BaseInit() => Init();

        protected abstract void SetUp(GameObject user);

        protected abstract bool Execute();
        protected override bool BaseExecute() => Execute();

        protected abstract void Init();
    }
}