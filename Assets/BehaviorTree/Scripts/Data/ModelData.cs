using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Data
{
    public class ModelData 
    {
        public TreeDataBase TreeDataBase { get; private set; }

        public TreeData TreeData { get; private set; }

        public void SetTreeDataBase(TreeDataBase data) => TreeDataBase = data;

        public void SetTreeData(TreeData data) => TreeData = data;
    }
}
