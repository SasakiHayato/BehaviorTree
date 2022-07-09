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
        public override void BaseSetup(GameObject user) => Setup(user);

        public override void BaseInit() => Initialize();

        protected abstract void Setup(GameObject user);

        protected abstract bool Execute();

        protected override bool BaseExecute() => Execute();

        protected abstract void Initialize();
    }
}