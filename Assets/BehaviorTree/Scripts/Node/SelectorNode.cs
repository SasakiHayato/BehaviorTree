using System;
using System.Collections.Generic;
using System.Linq;

namespace BehaviorTree.Node
{
    public class SelectorNode<Execution> : NodeBase where Execution : ExecuteBase
    {
        Func<bool> _func;
        public SelectorNode(List<Execution> type) : base()
        {
            _func = () => type.Any(e => e.IsExecute);
        }

        protected override void SetUp() { }

        protected override bool Execute()
        {
            return _func.Invoke();
        }
    }
}
