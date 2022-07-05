using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class DataBaseWindow : EditorWindow
{
    GraphViewBase _graphView = null;

    [OnOpenAsset(0)]
    public static bool Open(int instanceID, int line)
    {
        var asset = EditorUtility.InstanceIDToObject(instanceID);

        EditorWindow graphEditor = CreateInstance<DataBaseWindow>(); 
        graphEditor.Show();
        graphEditor.titleContent = new GUIContent($"{asset.name}_TreeEditor");

        return false;
    }

    private void OnEnable()
    {
        _graphView = new GraphViewBase();

        rootVisualElement.Add(_graphView);
    }
}
