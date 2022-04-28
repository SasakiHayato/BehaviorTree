using GraphProcessor;

namespace BehaviorTreeEditor
{
    [System.Serializable]
    [NodeMenuItem("Custom/BehaviorTree/Sequence")]
    public class SequenceNode : BaseNode
    {
        [Input("Node")] public BaseNode BaseNode;
        [Output("Next", allowMultiple = true)] public BaseNode aBaseNode;

        public override string name => "SequenceNode";

        protected override void Process()
        {

        }
    }
}