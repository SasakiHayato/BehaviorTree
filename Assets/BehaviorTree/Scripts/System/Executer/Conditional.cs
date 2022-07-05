using UnityEngine;

namespace BehaviorTree.Execute
{
    /// <summary>
    /// Conditionを作成する際の基底クラス
    /// このクラスを派生してAIの行動条件の作成をする。
    /// </summary>
    [System.Serializable]
    public abstract class Conditional : ExecuteBase
    {
        public override void BaseInit() => Init();

        public override void BaseSetUp(GameObject user) => SetUp(user);

        protected abstract void SetUp(GameObject user);

        protected abstract bool Try();

        protected override bool BaseExecute() => Try();

        protected abstract void Init();
    }
}

