using System.Collections.Generic;
using System.Linq;

namespace BehaviorTree.Node
{
    public class SequenceNode<Execution> : NodeBase where Execution : ExecuteBase
    {
        int _executeID;
        bool _isAll;

        List<Execution> _executeList;

        public SequenceNode(List<Execution> type, bool isExecuteAll = true) : base()
        {
            _executeList = type;
            _isAll = isExecuteAll;
        }
        protected override void SetUp() 
        {
            _executeID = 0;
        }

        protected override bool Execute()
        {
            if (_isAll)
            {
                return _executeList.All(e => e.IsExecute);
            }
            else
            {
                return OnNext();
            }
        }

        bool OnNext()
        {
            if (_executeList.Count <= 0 || _executeList.Count <= _executeID)
            {
                _executeID = 0;
                return true;
            }

            if (_executeList[_executeID].IsExecute)
            {
                _executeID++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
