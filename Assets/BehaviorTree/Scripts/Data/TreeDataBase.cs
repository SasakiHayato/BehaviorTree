using UnityEngine;
using System.Collections.Generic;
using BehaviorTree.Node;

namespace BehaviorTree.Data
{
    /// <summary>
    /// AI行動のデータ作成クラス
    /// </summary>

    [CreateAssetMenu(fileName = "TreeData")]
    public class TreeDataBase : ScriptableObject
    {
        [SerializeField] ConditionalNode _mastarCodition;

        [SerializeField] List<TreeData> _treeDataList;

        List<NodeBase> _nodeList;

        /// <summary>
        /// 根幹の条件の成否を返す
        /// </summary>
        public bool IsAccess => _mastarCodition.IsProcess;
        public List<TreeData> TreeDataList => _treeDataList;

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
            foreach (TreeData data in _treeDataList)
            {
                _nodeList.Add(data.Action);
                _nodeList.Add(data.Condition);
            }
        }
    }
}

