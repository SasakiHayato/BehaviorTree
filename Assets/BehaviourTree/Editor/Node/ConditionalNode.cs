using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System.Collections.Generic;

using BehaviourTree.Data;

namespace BehaviourTree.Edit
{
    public class ConditionalNode : BaseNode
    {
        public ConditionalNode() : base(true, true)
        {
            title = "Condition";

            mainContainer.Add(SetPopup());
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
    }
}