using GraphProcessor;
using UnityEngine;

namespace BehaviorTree
{
    [System.Serializable]
    [NodeMenuItem("Custom/BehaviorTree/Conditional")]
    public class ConditionalNode : BaseNode
    {
        [Output("Send")] BaseNode _node;

        [SerializeField] Data.Conditional _conditionalData;

        public override string name => $"Conditional Type:{_conditionalData.Type}";

        protected override void Process()
        {
            
        }
    }
}
