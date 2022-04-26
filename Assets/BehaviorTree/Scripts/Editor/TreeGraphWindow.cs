using UnityEngine;
using UnityEditor;
using GraphProcessor;
using UnityEngine.Assertions;

/// <summary>
/// Windowの生成
/// </summary>

namespace BehaviourTree
{
    namespace TreeEditor
    {
        public class TreeGraphWindow : BaseGraphWindow
        {
            const string FileName = "BehaviorTreeWindow";

            protected override void InitializeWindow(BaseGraph graph)
            {
                Assert.IsNotNull(graph, "BaseGraph is Null");

                // Windowのタイトル設定
                titleContent = new GUIContent(ObjectNames.NicifyVariableName(FileName));

                if (graphView == null) graphView = new BehaviorTreeGraphView(this);

                rootView.Add(graphView);
            }
        }
    }
}
