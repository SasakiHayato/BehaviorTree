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

            this.AddManipulator(new SelectionDropper());
        }
    }
}