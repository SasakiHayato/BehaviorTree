using UnityEngine;

namespace BehaviorTree.Data
{
    /// <summary>
    /// BehaviorTreeUserのデータクラス
    /// </summary>
    public class BehaviorTreeUserData
    {
        public BehaviorTreeUserData(BehaviorTreeUser user, Transform transform)
        {
            Offset = transform;
            User = user;
        }

        public Transform Offset { get; private set; }

        public BehaviorTreeUser User { get; private set; }
        
        public int LimitConditionalCount { get; private set; }

        public void SetLimitConditionalCount(int count) => LimitConditionalCount = count;
        
        public bool IsLimitCondition() => LimitConditionalCount > 0;
    }
}
