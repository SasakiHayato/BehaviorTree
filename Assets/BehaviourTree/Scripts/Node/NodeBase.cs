using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BehaviourTree.Node
{
    /// <summary>
    /// ノード作成の際の基底クラス
    /// </summary>

    public abstract class NodeBase
    {
        public GameObject User { get; private set; }

        public void SetNodeUser(GameObject user) => User = user;

        public virtual void Init() { }

        public bool IsProcess => Execute();

        public Node Copy<Node>() where Node : NodeBase
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stream, this);
            stream.Position = 0;

            return (Node)binary.Deserialize(stream);
        }

        public abstract void SetUp();

        protected abstract bool Execute();
    }
}
