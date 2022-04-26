using UnityEngine;
using UnityEditor;
using GraphProcessor;
using UnityEngine.Assertions;

public class BehaviorTreeGraphWindow : BaseGraphWindow
{
    const string FileName = "BehaviorTreeWindow";

    protected override void InitializeWindow(BaseGraph graph)
    {
        Assert.IsNotNull(graph, "BaseGraph is Null");
        
        // Window�̃^�C�g���ݒ�
        titleContent = new GUIContent(ObjectNames.NicifyVariableName(FileName));

        if (graphView == null) graphView = new BehaviorTreeGraphView(this);

        rootView.Add(graphView);
    }
}
