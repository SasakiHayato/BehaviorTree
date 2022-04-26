using GraphProcessor;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BehaviorTreeGraph))]
public class BehaviorTreeGraphEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Process"))
        {
            var graph = target as BehaviorTreeGraph;
            var processor = new BehaviorTreeGraphProcesser(graph);
            processor.Run();
            Debug.Log(processor.Result);
        }
    }
}
