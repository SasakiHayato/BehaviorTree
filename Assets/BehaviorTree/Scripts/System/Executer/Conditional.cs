using UnityEngine;

namespace BehaviorTree.Execute
{
    /// <summary>
    /// Condition���쐬����ۂ̊��N���X
    /// ���̃N���X��h������AI�̍s�������̍쐬������B
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

