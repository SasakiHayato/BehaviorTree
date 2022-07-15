using UnityEngine;
using UnityEditor;

namespace BehaviourTree.Edit
{
    [CustomEditor(typeof(BehaviorTreeUser))]
    public class CustomBehaviourUser : Editor
    {
        string _name;
        bool _isOpen = false;

        private void OnEnable()
        {
            BehaviorTreeUser user = target as BehaviorTreeUser;
            _name = user.gameObject.name;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("OpenNodeEditor") && !_isOpen)
            {
                _isOpen = true;
                DataBaseWindow.Open(_name, () => Close());
            }
        }

        void Close()
        {
            _isOpen = false;
        }
    }
}