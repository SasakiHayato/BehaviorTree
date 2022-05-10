using UnityEngine;
using GraphProcessor;

namespace BehaviorTree
{
    public class TreeUser : MonoBehaviour
    {
        [SerializeField] string _dataPath;

        public void SetUp()
        {
            BaseGraph graph = Resources.Load<BaseGraph>(_dataPath);
            Debug.Log(graph);
        }

        public void Execute()
        {

        }
    }
}
