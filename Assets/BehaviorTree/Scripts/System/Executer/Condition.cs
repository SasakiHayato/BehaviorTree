using UnityEngine;

namespace BehaviorTree.Execute
{
    [System.Serializable]
    public abstract class Condition : ExecuteBase
    {
        public override void BaseInit() => Init();

        public override void BaseSetUp(GameObject user) => SetUp(user);

        protected abstract void SetUp(GameObject user);

        protected abstract bool Try();

        protected override bool BaseExecute() => Try();

        protected abstract void Init();
    }
}

