using System.Collections.Generic;
using UnityEngine;
using BehaviorTree.Execute;

namespace BehaviorTree.Node
{
    [System.Serializable]
    public class ActionNode : NodeBase
    {
        [SerializeReference, SubclassSelector]
        List<Action> _actionList;

        SequenceNode<Action> _sequenceNode;

        protected override void SetUp()
        {
            if (_actionList == null || _actionList.Count <= 0)
            {
                return;
            }

            _actionList.ForEach(a => a.BaseSetUp(User));
            _sequenceNode = new SequenceNode<Action>(_actionList, false);
        }

        protected override bool Execute()
        {
            return _sequenceNode.IsProcess;
        }
    }
}