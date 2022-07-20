using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System;
using System.Linq;
using System.Collections.Generic;

using BehaviourTree.Data;
using BehaviourTree.Execute;

namespace BehaviourTree.Edit
{
    public class ConditionalNode : BaseNode
    {
        public ConditionalNode() : base(true, true)
        {
            title = "Condition";

            mainContainer.Add(SetPopup());
            mainContainer.Add(SetConditionCount());
        }

        VisualElement SetPopup()
        {
            var choices = new List<ConditionType> { ConditionType.Sequence, ConditionType.Selector };
            
            var popupField = new PopupField<ConditionType>("ConditionalType", choices, 0);

            popupField.value = ConditionType.Sequence;
            popupField.RegisterCallback<ChangeEvent<ConditionType>>((evt) =>
            {
                Debug.Log(evt.newValue);
            });

            return popupField;
        }

        VisualElement SetConditionCount()
        {
            IntegerField field = new IntegerField("ConditionCount");

            field.RegisterCallback<ChangeEvent<int>>(e =>
            {
                CreateConditionField(e.newValue);
            });

            return field;
        }

        void CreateConditionField(int createConut)
        {
            for (int i = 0; i < createConut; i++)
            {
                mainContainer.Add(SetCondition());
            }
        }

        VisualElement SetCondition()
        {
            List<Type> list = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.IsClass && a.IsSubclassOf(typeof(BehaviourConditional)))
                .ToList();

            PopupField<Type> field = new PopupField<Type>("Execute", list, 0);

            field.RegisterCallback<ChangeEvent<Type>>(e =>
            { 
                
            });

            return field;
        }
    }
}