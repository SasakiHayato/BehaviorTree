# if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using GraphProcessor;

namespace BehaviorTree
{
    [CreateAssetMenu(menuName = "BehaviorTreeGraph")]
    public class BehaviorTreeGraph : BaseGraph
    {
        //public void Execute()
        //{
        //    var process = new TreeGraphExecutor(this);
        //    process.Run();
        //}

        [OnOpenAsset(0)]
        public static bool OnBaseGraphOpened(int instanceID, int line)
        {
            var asset = EditorUtility.InstanceIDToObject(instanceID) as BehaviorTreeGraph;

            if (asset == null) return false;

            var window = EditorWindow.GetWindow<BehaviorTreeGraphWindow>();
            window.InitializeGraph(asset);

            return true;
        }
    }
}

#endif
