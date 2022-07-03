using System.Collections.Generic;
using UnityEngine;
using BehaviorTree.Execute;
using BehaviorTree.Data;

namespace BehaviorTree.Node
{
    /// <summary>
    /// Conditionを判定するノード
    /// 
    /// 毎判定時、Conditionを初期化を行う
    /// </summary>
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

            _couditionList.ForEach(c => c.BaseSetUp(User));

            _selectorNode = new SelectorNode<Condition>(_couditionList);
            _sequenceNode = new SequenceNode<Condition>(_couditionList);
        }

        protected override bool Execute()
        {
            bool isExecute = false;

            if (_couditionList == null || _couditionList.Count <= 0)
            {
                return true;
            }

            switch (_conditionType)
            {
                case ConditionType.Selector: isExecute = _selectorNode.IsProcess; break;
                case ConditionType.Sequence: isExecute = _sequenceNode.IsProcess; break;
            }

            _couditionList.ForEach(c => c.BaseInit());

            return isExecute;
        }
    }
}