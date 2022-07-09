using UnityEngine;
using System.Collections.Generic;
using BehaviorTree.Node;

namespace BehaviorTree.Data
{
    /// <summary>
    /// AI行動のデータ作成クラス
    /// </summary>

    [CreateAssetMenu(fileName = "BehaviorTreeData")]
    public class TreeDataBase : ScriptableObject
    {
        [SerializeField] ConditionalNode _mastarCodition;
        [SerializeField] TreeData _treeData;
        
        List<NodeBase> _nodeList;

        public int ID { get; set; }

        /// <summary>
        /// 根幹の条件の成否を返す
        /// </summary>
        public bool IsAccess => _mastarCodition.IsProcess;

        public bool HasCondition => _mastarCodition.HasCondition;

        public TreeData TreeData => _treeData;

        public List<NodeBase> NodeList
        {
            get
            {
                if (_nodeList == null)
                {
                    _nodeList = new List<NodeBase>();
                    AddNode();
                }

                return _nodeList;
            }
        }

        void AddNode()
        {
            _nodeList.Add(_mastarCodition);
            foreach (ExecuteData data in _treeData.ExecuteList)
            {
                _nodeList.Add(data.Action);
                _nodeList.Add(data.Condition);
            }
        }
    }
}

