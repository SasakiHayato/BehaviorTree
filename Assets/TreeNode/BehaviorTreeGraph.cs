# if UNITY_EDITOR

using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using GraphProcessor;

[CreateAssetMenu (menuName = "BehaviorTreeGraph")]
public class BehaviorTreeGraph : BaseGraph
{
    //public void Run()
    //{
    //    var process = new BehaviorTreeGraphProcesser(this);
    //    process.Run();
    //    Debug.Log(process.Result);
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

    //@ŠJ‚¢‚½Û‚ÉResultNode‚ª‚È‚¯‚ê‚Î’Ç‰Á
    protected override void OnEnable()
    {
        base.OnEnable();

        if (!nodes.Any(n => n is ResultNode))
        {
            AddNode(BaseNode.CreateFromType<ResultNode>(Vector2.zero));
        }
    }
}

#endif
