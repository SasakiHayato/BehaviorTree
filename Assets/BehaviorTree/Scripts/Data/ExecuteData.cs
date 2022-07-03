using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Data
{
    [System.Serializable]
    public class ExecuteData
    {
        [SerializeField] ConditionType _conditionType;
        [SerializeField] List<TreeDataBase> _treeDataList;

        public ConditionType ConditionType => _conditionType;
        public List<TreeDataBase> TreeList => _treeDataList;
    }
}
