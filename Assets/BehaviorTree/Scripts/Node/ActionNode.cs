using System.Collections.Generic;
using UnityEngine;
using BehaviorTree.Execute;

namespace BehaviorTree.Node
{
    /// <summary>
    /// Actionを行うノード
    /// 
    /// 行動終了時、Actionの初期化を行う
    /// </summary>
    [System.Serializable]
    public class ActionNode : NodeBase
    {
        [SerializeReference, SubclassSelector]
        List<Action> _actionList;

        SequenceNode<Action> _sequenceNode;

        int _conut;

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
            if (_conut >= _actionList.Count)
            {
                Init();
                return true;
            }
            else
            {
                if (_sequenceNode.IsProcess)
                {
                    _actionList.ForEach(a => a.BaseInit());
                    _conut++;
                }

                return false;
            }
        }

        public override void Init()
        {
            base.Init();

            _conut = 0;
            _actionList.ForEach(a => a.BaseInit());
        }
    }
}