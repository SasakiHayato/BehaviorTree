using System;
using GraphProcessor;

[Serializable]
[NodeMenuItem("Custam/Add")]
public class AddNode : BaseNode
{
    [Input(name = "A")] public float input_1;
    [Input(name = "B")] public float input_2;

    [Output(name = "Out", allowMultiple = false)]
    public float output;

    public override string name => "Add";

    protected override void Process()
    {
        output = input_1 + input_2;
    }
}
