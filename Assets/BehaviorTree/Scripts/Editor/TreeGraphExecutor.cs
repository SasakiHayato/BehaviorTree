using GraphProcessor;
using System.Linq;

namespace BehaviorTree
{
    public class TreeGraphExecutor : BaseGraphProcessor
    {
        public IAction Execute { get; private set; }
        public TreeGraphExecutor(BaseGraph graph) : base(graph) { }

        public override void UpdateComputeOrder()
        {
            graph.nodes.OrderBy(n => n.computeOrder);
        }

        public override void Run()
        {

        }
    }
}
