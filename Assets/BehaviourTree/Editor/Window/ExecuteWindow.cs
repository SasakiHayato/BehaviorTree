using UnityEditor;
using System;

namespace BehaviourTree.Edit
{
    public class ExecuteWindow : EditorWindow
    {
        Action _action;

        private void OnEnable()
        {
            var view = new ExecuteDataGraphView();
            rootVisualElement.Add(view);
        }

        public void SetCloseAction(Action action)
        {
            _action = action;
        }

        private void OnDestroy()
        {
            _action?.Invoke();
        }
    }
}