using GraphProcessor;
using UnityEngine;
using BehaviorTree;

namespace BehaviorTreeEditor
{
    public class RepearterNode : BaseNode
    {
        [Output("ConectBranch", allowMultiple = true)] BranchNode _branchNode;

        [SerializeField] GameObject _user;

        public override string name => "Repearter";

        protected override void Process()
        {
            
        }
    }
}
