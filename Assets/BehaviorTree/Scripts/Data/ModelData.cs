
namespace BehaviorTree.Data
{
    /// <summary>
    /// TreeModelのデータクラス。ここを参照してTreeModelを更新する
    /// </summary>
    public class ModelData 
    {
        public TreeDataBase TreeDataBase { get; private set; }

        public TreeData TreeData { get; private set; }

        public void SetTreeDataBase(TreeDataBase data) => TreeDataBase = data;

        public void SetTreeData(TreeData data) => TreeData = data;
    }
}
