using UnityEngine;

namespace BehaviorTree.Execute
{
    [System.Serializable]
    public abstract class Condition : ExecuteBase
    {
        protected abstract void Init(GameObject user);

        public override void SetUp(GameObject user) => Init(user);

        protected abstract bool Try();

        protected override bool Execute() => Try();
    }
}

