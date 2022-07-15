using UnityEngine;
using UnityEditor;
using BehaviourTree;

[CustomEditor(typeof(BehaviorTreeUser))]
public class CustomBehaviourUser : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
    }
}
