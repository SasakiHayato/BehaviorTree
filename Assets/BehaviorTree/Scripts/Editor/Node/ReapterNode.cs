using GraphProcessor;

namespace BehaviourTree
{
    namespace TreeEditor
    {
        public class ReapterNode : BaseNode
        {
            [Output("ConectBranch", allowMultiple = true)] BranchNode _branchNode;
            
            public override string name => "Reapter";

            protected override void Process()
            {
                
            }
        }
    }
}
