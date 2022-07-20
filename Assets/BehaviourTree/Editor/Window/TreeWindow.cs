using UnityEditor;
using System;

namespace BehaviourTree.Edit
{
    public class TreeWindow : EditorWindow
    {
        Action _action;

        void OnEnable()
        {
            TreeGraphView view = new TreeGraphView();
            rootVisualElement.Add(view);
        }

        internal void SetCloseAction(Action action)
        {
            _action = action;
        }

        void OnDestroy()
        {
            _action?.Invoke();
        }
    }
}