#if UNITY_EDITOR

using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using GraphProcessor;

namespace BehaviorTreeEditor
{
    /// <summary>
    /// BehaviorTreeのデータクラス
    /// </summary>

    [CreateAssetMenu(menuName = "BehaviorTreeGraph")]
    public class TreeGraph : BaseGraph
    {
        // ダブルクリックでWindowを開くようにする
        [OnOpenAsset(0)]
        public static bool OnBaseGraphOpened(int instanceID, int line)
        {
            var asset = EditorUtility.InstanceIDToObject(instanceID) as TreeGraph;

            if (asset == null) return false;

            var window = EditorWindow.GetWindow<TreeGraphWindow>();
            window.InitializeGraph(asset);

            return true;
        }

        // ReapterNodeがなければ作成する
        protected override void OnEnable()
        {
            base.OnEnable();

            if (!nodes.Any(n => n is ReapterNode))
            {
                AddNode(BaseNode.CreateFromType<ReapterNode>(Vector2.zero));
            }
        }
    }
}
#endif
