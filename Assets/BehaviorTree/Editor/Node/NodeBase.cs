using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public abstract class NodeBase : Node
{
    public NodeBase()
    {
        title = Path;

        mainContainer.Add(new TextField(title));
    }

    string _path;
    internal string Path 
    { 
        get
        {
            string path = SetPath();

            if (path == "")
            {
                path = "Node";
            }

            return path;
        }
    }

    protected abstract string SetPath();
}
