using UnityEngine;
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

        [SerializeField] TreeData _treeData;

        /// <summary>
        /// �����̏����̐��ۂ�Ԃ�
        /// </summary>
        public bool IsProcess => _mastarCodition.IsProcess;
        public TreeData TreeData => _treeData;
    }
}

