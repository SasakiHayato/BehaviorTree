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

        [SerializeField] List<TreeData> _treeData;

        /// <summary>
        /// �����̏����̐��ۂ�Ԃ�
        /// </summary>
        public bool IsProcess => _mastarCodition.IsProcess;
        public List<TreeData> TreeData => _treeData;
    }
}

