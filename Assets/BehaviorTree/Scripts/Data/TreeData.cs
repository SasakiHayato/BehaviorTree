using UnityEngine;
using BehaviorTree.Node;

namespace BehaviorTree.Data
{
    /// <summary>
    /// AI行動のデータクラス
    /// </summary>
    [System.Serializable]
    public class TreeData
    {
        [SerializeField] TreeExecuteType _treeExecuteType;
        [SerializeField] ConditionalNode _condition;
        [SerializeField] ActionNode _action;
    }
}