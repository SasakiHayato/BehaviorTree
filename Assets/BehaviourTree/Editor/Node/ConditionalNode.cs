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
        List<VisualElement> _conditionList;

        public ConditionalNode() : base(true, true)
        {
            title = "Condition";

            _conditionList = new List<VisualElement>();

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
                ResetConditionField();
                CreateConditionField(e.newValue);
            });

            return field;
        }

        void CreateConditionField(int createConut)
        {
            for (int i = 0; i < createConut; i++)
            {
                VisualElement visual = SetCondition();
                _conditionList.Add(visual);
                mainContainer.Add(visual);
            }
        }

        void ResetConditionField()
        {
            if (_conditionList.Count <= 0)
            {
                return;
            }

            _conditionList.ForEach(c => mainContainer.Remove(c));
            _conditionList = new List<VisualElement>();
        }

        VisualElement SetCondition()
        {
            List<Type> list = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.IsClass && a.IsSubclassOf(typeof(BehaviourConditional)))
                .ToList();

            PopupField<Type> field = new PopupField<Type>("Execute", list, 0);

            return field;
        }
    }
}