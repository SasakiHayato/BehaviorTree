using UnityEngine;
using UnityEditor;
using GraphProcessor;
using UnityEngine.Assertions;

/// <summary>
/// WindowÇÃê∂ê¨
/// </summary>

namespace BehaviorTreeEditor
{
    public class TreeGraphWindow : BaseGraphWindow
    {
        const string FileName = "BehaviorTreeWindow";

        protected override void InitializeWindow(BaseGraph graph)
        {
            Assert.IsNotNull(graph, "BaseGraph is Null");

            // WindowÇÃÉ^ÉCÉgÉãê›íË
            titleContent = new GUIContent(ObjectNames.NicifyVariableName(FileName));

            if (graphView == null) graphView = new TreeGraphView(this);

            rootView.Add(graphView);
        }
    }
}
