using GraphProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;
using UnityEditor;

namespace BehaviorTreeEditor
{
    public class TreeGraphView : BaseGraphView
    {
        public TreeGraphView(EditorWindow window) : base(window) { }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {

        }

        protected override bool canDeleteSelection
        {
            get { return !selection.Any(s => s is RepearterNode); }
        }
    }
}