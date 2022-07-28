using UnityEngine.UIElements;

namespace BehaviourTree.Edit
{
    public class ExecuteNode : BaseNode
    {
        public ExecuteNode() : base()
        {
            mainContainer.Add(OpenWindow());
        }

        VisualElement OpenWindow()
        {
            Button button = new Button();

            button.name = "Open";

            TextField text = new TextField();

            string a;

            TextField field = new TextField();

            field.RegisterCallback<ChangeEvent<string>>(e =>
            {
                _title = e.newValue;
            });

            text.RegisterValueChangedCallback<ChangeEvent<string>>(e =>
            {
                a = e.newValue;
            });

            return button;
        }

        protected override string SetTitle()
        {
            return "ExecuteData";
        }
    }
}
