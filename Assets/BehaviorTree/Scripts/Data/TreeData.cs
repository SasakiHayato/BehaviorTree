using UnityEngine;
using BehaviorTree.Node;

namespace BehaviorTree.Data
{
    /// <summary>
    /// AI�s���̃f�[�^�N���X
    /// </summary>
    [System.Serializable]
    public class TreeData
    {
        [SerializeField] TreeExecuteType _treeExecuteType;
        [SerializeField] ConditionalNode _condition;
        [SerializeField] ActionNode _action;
    }
}