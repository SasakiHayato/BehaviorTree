using System.Collections.Generic;
using System.Linq;

namespace BehaviorTree.Node
{
    /// <summary>
    /// �ǂꂩ�̎��s�𑀍삷��m�[�h
    /// 
    /// System.Linq Any()�̓���
    /// </summary>
    /// <typeparam name="Execution"></typeparam>
    public class SelectorNode<Execution> : NodeBase where Execution : ExecuteBase
    {
        List<Execution> _executeList;
        public SelectorNode(List<Execution> type) : base()
        {
            _executeList = type;
        }

        protected override void SetUp() { }

        protected override bool Execute()
        {
            return _executeList.Any(e => e.IsExecute);
        }
    }
}
