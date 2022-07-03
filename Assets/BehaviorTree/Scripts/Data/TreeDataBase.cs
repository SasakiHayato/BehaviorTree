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

        [SerializeField] List<TreeData> _treeData;

        /// <summary>
        /// 根幹の条件の成否を返す
        /// </summary>
        public bool IsProcess => _mastarCodition.IsProcess;
        public List<TreeData> TreeData => _treeData;
    }
}

