using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace BehaviourTree.Edit
{
    public class ExecuteDataGraphView : GraphView
    {
        public ExecuteDataGraphView()
        {
            style.flexGrow = 1;
            style.flexShrink = 1;
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

            Insert(0, new GridBackground());

            this.AddManipulator(new SelectionDragger());

            CreateSearchNode();
        }
        void CreateSearchNode()
        {
            var model = ScriptableObject.CreateInstance<SearchNodeModel>();
            model.Initialize(this);

            nodeCreationRequest += context =>
            {
                SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), model);
            };
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            List<Port> list = new List<Port>();

            foreach (Port item in ports.ToList())
            {
                if (startPort.node == item.node ||
                    startPort.direction == item.direction ||
                    startPort.portType != item.portType)
                {
                    continue;
                }

                list.Add(item);
            }

            return list;
        }
    }
}