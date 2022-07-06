using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalNode : NodeBase
{
    public ConditionalNode() : base() { }
    protected override string SetPath() => "Condition";
}
