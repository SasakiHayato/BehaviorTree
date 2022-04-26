using Unity.Jobs;
using System.Collections.Generic;
using System.Linq;

namespace GraphProcessor
{
    public class BehaviorTreeGraphProcesser : BaseGraphProcessor
    {
        private List<BaseNode> processList;
        public float Result { get; private set; }

        public BehaviorTreeGraphProcesser(BaseGraph graph) : base(graph) { }

        public override void UpdateComputeOrder()
        {
            processList = graph.nodes.OrderBy(n => n.computeOrder).ToList();
        }

        public override void Run()
        {
            for (int i = 0; i < processList.Count; i++)
            {
                processList[i].OnProcess();
            }

            JobHandle.ScheduleBatchedJobs();

            var resultNodes = processList.OfType<ResultNode>().FirstOrDefault();
            Result = resultNodes.Resut;
        }
    }
}
