using System.Collections.Generic;
using UnityEngine;
using BehaviorTree.Execute;

namespace BehaviorTree.Node
{
    [System.Serializable]
    public class ConditionalNode : NodeBase
    {
        [SerializeField] ConditionType _conditionType;

        [SerializeReference, SubclassSelector]
        List<Condition> _couditionList;

        SelectorNode<Condition> _selectorNode;
        SequenceNode<Condition> _sequenceNode;
        protected override void SetUp()
        {
            if (_couditionList == null || _couditionList.Count <= 0)
            {
                return;
            }

            _couditionList.ForEach(c => c.SetUp(User));
            _selectorNode = new SelectorNode<Condition>(_couditionList);
        }

        protected override bool Execute()
        {
            switch (_conditionType)
            {
                case ConditionType.Selector: return _selectorNode.IsProcess;
                case ConditionType.Sequence: return _sequenceNode.IsProcess;
                default: return false;
            }
        }
    }
}