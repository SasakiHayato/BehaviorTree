using UnityEngine;

namespace BehaviorTree.Execute
{
    /// <summary>
    /// Actionを作成する際の基底クラス。
    /// このクラスを派生してAI行動を作成する。
    /// </summary>
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