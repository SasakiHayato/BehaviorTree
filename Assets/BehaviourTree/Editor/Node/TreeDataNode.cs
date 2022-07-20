using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace BehaviourTree.Edit
{
    public class TreeDataNode : BaseNode
    {
        int _priority;
        string _title;

        public TreeDataNode() : base(true, false)
        {
            title = "TreeData";

            mainContainer.Add(SetTitle());
            mainContainer.Add(SetPriority());
            mainContainer.Add(OpenExecuteData());
        }

        VisualElement OpenExecuteData()
        {
            Button button = new Button();
            button.text = "OpenExecuteData";

            button.clicked += () => ShowExecuteWindow();

            return button;
        }

        void ShowExecuteWindow()
        {
            ExecuteWindow window = ScriptableObject.CreateInstance<ExecuteWindow>();
            window.Show();

            if (_title == "")
            {
                _title = $"Priority{_priority}";
            }

            window.titleContent = new GUIContent($"{_title}_ExecuteData");
        }

        VisualElement SetPriority()
        {
            IntegerField field = new IntegerField();

            field.RegisterCallback<ChangeEvent<int>>(e =>
            {
                _priority = e.newValue;
            });

            return field;
        }

        VisualElement SetTitle()
        {
            TextField field = new TextField();

            field.RegisterCallback<ChangeEvent<string>>(e =>
            {
                _title = e.newValue;
            });

            return field;
        }
    }
}