
namespace BehaviorTree.Data
{
    /// <summary>
    /// TreeModel�̃f�[�^�N���X�B�������Q�Ƃ���TreeModel���X�V����
    /// </summary>
    public class ModelData 
    {
        public TreeDataBase TreeDataBase { get; private set; }

        public TreeData TreeData { get; private set; }

        public void SetTreeDataBase(TreeDataBase data) => TreeDataBase = data;

        public void SetTreeData(TreeData data) => TreeData = data;
    }
}
