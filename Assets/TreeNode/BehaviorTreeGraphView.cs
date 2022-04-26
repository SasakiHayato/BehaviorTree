using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public class BehaviorTreeGraphView : BaseGraphView
{
    public BehaviorTreeGraphView(EditorWindow window) : base(window) { }

    public override IEnumerable<(string path, Type type)> FilterCreateNodeMenuEntries()
    {
        foreach (var nodeMune in NodeProvider.GetNodeMenuEntries())
        {
            if (nodeMune.type == typeof(ResultNode))
            {
                continue;
            }

            yield return nodeMune;
        }
    }

    protected override bool canDeleteSelection
    {
        get { return !selection.Any(s => s is ResultNode); }
    }
}
