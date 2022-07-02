using UnityEngine;

namespace BehaviorTree.Execute
{
    public abstract class Action : ExecuteBase
    {
        public override void SetUp(GameObject user) => Init(user);
        
        protected abstract void Init(GameObject user);

        protected abstract bool ExecuteAction();
        protected override bool Execute() => ExecuteAction();
    }
}