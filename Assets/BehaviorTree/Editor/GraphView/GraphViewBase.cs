using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public class GraphViewBase : GraphView
{
    public GraphViewBase() : base()
    {
        style.flexGrow = 1;
        style.flexShrink = 1;

        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

        Insert(0, new GridBackground());
        this.AddManipulator(new SelectionDragger());

        SetEvent();
    }

    void SetEvent()
    {
        nodeCreationRequest += context =>
        {
            Node node = new Node();
            AddElement(node);
        };
    }
}
