using System.Collections.Generic;
using System;
using System.Linq;

namespace BehaviorTree.Node
{
    public class SequenceNode<Execution> : NodeBase where Execution : ExecuteBase
    {
        Func<bool> _func;
        public SequenceNode(List<Execution> type) : base()
        {
            _func = () => type.All(e => e.IsExecute);
        }
        protected override void SetUp() { }

        protected override bool Execute()
        {
            return _func.Invoke();
        }
    }
}
