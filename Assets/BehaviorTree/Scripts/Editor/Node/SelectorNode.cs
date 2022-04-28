using GraphProcessor;

namespace BehaviorTreeEditor
{
    [System.Serializable]
    [NodeMenuItem("Custom/BehaviorTree/Selecter")]
    public class SelectorNode : BaseNode
    {
        [Input("GetNode")] int a;
    }
}
