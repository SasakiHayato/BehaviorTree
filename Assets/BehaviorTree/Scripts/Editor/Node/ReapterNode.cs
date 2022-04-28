using GraphProcessor;
using UnityEngine;
using BehaviourTree;

namespace BehaviorTreeEditor
{
    public class ReapterNode : BaseNode
    {
        [Output("ConectBranch", allowMultiple = true)] BranchNode _branchNode;

        [SerializeField] GameObject _user;

        public override string name => "Reapter";

        protected override void Process()
        {
            //_user.AddComponent<TreeUser>();
        }
    }
}
