using UnityEngine;
using System.Collections.Generic;
using BehaviorTree.Node;

namespace BehaviorTree.Data
{
    /// <summary>
    /// AI�s���̃f�[�^�쐬�N���X
    /// </summary>

    [CreateAssetMenu(fileName = "TreeData")]
    public class TreeDataBase : ScriptableObject
    {
        [SerializeField] ConditionalNode _mastarCodition;

        [SerializeField] List<TreeData> _treeDataList;

        List<NodeBase> _nodeList;

        /// <summary>
        /// �����̏����̐��ۂ�Ԃ�
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

