using GraphProcessor;
using System.Linq;

namespace BehaviorTree
{
    /// <summary>
    /// Tree�̎��s�����N���X
    /// </summary>

    public class TreeGraphExecutor : BaseGraphProcessor
    {
        public TreeGraphExecutor(BaseGraph graph) : base(graph) { }

        public override void UpdateComputeOrder()
        {
            graph.nodes.OrderBy(n => n.computeOrder);
        }

        public override void Run()
        {
            graph.nodes[0].OnProcess();
        }
    }
}
