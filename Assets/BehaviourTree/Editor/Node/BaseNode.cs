
namespace BehaviourTree.Edit
{
    using UnityEditor.Experimental.GraphView;

    public class BaseNode : Node
    {
        protected Port _input;
        protected Port _output;

        public BaseNode(bool isSetInput, bool isSetOutput)
        {
            if (isSetInput)
            {
                _input = Port.Create<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(Port));
                inputContainer.Add(_input);
            }

            if (isSetOutput)
            {
                _output = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(Port));
                outputContainer.Add(_output);
            }
        }
    }
}