using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;
using System.Linq;
using System.Collections.Generic;
using BehaviourTree.Execute;

namespace BehaviourTree.Edit
{
    public class ActionNode : BaseNode
    {
        List<VisualElement> _list;

        public ActionNode() : base(true, false)
        {
            title = "Action";

            _list = new List<VisualElement>();
            mainContainer.Add(SetActionCount());
        }

        VisualElement SetActionCount()
        {
            IntegerField field = new IntegerField();

            field.RegisterCallback<ChangeEvent<int>>(e =>
            {
                ResetActionField();
                CreateActionField(e.newValue);
            });

            return field;
        }

        void ResetActionField()
        {
            if (_list.Count <= 0)
            {
                return;
            }

            _list.ForEach(l => mainContainer.Remove(l));
            _list = new List<VisualElement>();
        }

        void CreateActionField(int createCount)
        {
            for (int i = 0; i < createCount; i++)
            {
                mainContainer.Add(SetAction());
            }
        }

        VisualElement SetAction()
        {
            List<Type> list = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.IsClass && a.IsSubclassOf(typeof(BehaviourAction)))
                .ToList();

            PopupField<Type> field = new PopupField<Type>("Execute", list, 0);

            return field;
        }
    }
}
