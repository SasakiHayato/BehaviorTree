#if UNITY_EDITOR

using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using GraphProcessor;

namespace BehaviorTreeEditor
{
    /// <summary>
    /// BehaviorTree�̃f�[�^�N���X
    /// </summary>

    [CreateAssetMenu(menuName = "BehaviorTreeGraph")]
    public class TreeGraph : BaseGraph
    {
        // �_�u���N���b�N��Window���J���悤�ɂ���
        [OnOpenAsset(0)]
        public static bool OnBaseGraphOpened(int instanceID, int line)
        {
            var asset = EditorUtility.InstanceIDToObject(instanceID) as TreeGraph;

            if (asset == null) return false;

            var window = EditorWindow.GetWindow<TreeGraphWindow>();
            window.InitializeGraph(asset);

            return true;
        }

        // ReapterNode���Ȃ���΍쐬����
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
