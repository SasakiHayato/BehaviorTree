using GraphProcessor;
using UnityEngine;
using System.Collections.Generic;

namespace BehaviourTree
{
    namespace TreeEditor
    {
        [System.Serializable]
        [NodeMenuItem("Custom/BehaviorTree/Branch")]
        public class BranchNode : BaseNode
        {
            [Input("SetConditional")] public BranchNode _branch;

            [SerializeField] TreeManager.BlockType _blockType;
            [SerializeField] TreeManager.ConditionalType _conditionalType;
            [SerializeField] int _priority;
            [SerializeReference, SubclassSelector] List<IConditional> _setConditions;

            public override string name => "Branch";

            protected override void Process()
            {
                
            }
        }
    }
}
