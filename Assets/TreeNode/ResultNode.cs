using System;
using GraphProcessor;

[Serializable]
[NodeMenuItem("Custom/Result")]
public class ResultNode : BaseNode
{
    [Input(name = "Result")] public float input;

    private float result;
    public float Resut => result;

    public override string name => "Result";

    protected override void Process()
    {
        result = input;
    }
}
