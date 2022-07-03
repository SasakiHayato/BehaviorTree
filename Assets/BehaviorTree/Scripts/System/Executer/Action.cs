using UnityEngine;

namespace BehaviorTree.Execute
{
    /// <summary>
    /// Action���쐬����ۂ̊��N���X�B
    /// ���̃N���X��h������AI�s�����쐬����B
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