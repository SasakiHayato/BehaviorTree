using GraphProcessor;
using UnityEngine;
using System.Collections.Generic;
using BehaviorTree;

namespace BehaviorTreeEditor
{
    [System.Serializable]
    [NodeMenuItem("Custom/BehaviorTree/Branch")]
    public class BranchNode : BaseNode
    {
        [Input("Get")] public BranchNode _reapter;
        [Input("GetConditional")] public ConditionalNode _condition;

        [SerializeField] ConditionalType _type;
        [SerializeField] int _priority;
        
        public override string name => "BranchNode";

        protected override void Process()
        {

        }
    }
}
