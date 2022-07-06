using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class ConditionalNode : NodeBase
{
    
    public ConditionalNode() : base() { }

    protected override string SetPath() => "Condition";
}
