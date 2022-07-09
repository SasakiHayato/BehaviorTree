/// <summary>
/// BehaviorTreeUserのデータクラス
/// </summary>

namespace BehaviorTree.Data
{
    public class UserData
    {
        public UserData(BehaviorTreeUser user)
        {
            User = user;
        }

        public BehaviorTreeUser User { get; private set; }
        
        public int LimitConditionalCount { get; private set; }

        public void SetLimitConditionalCount(int count) => LimitConditionalCount = count;
        
        public bool IsLimitCondition() => LimitConditionalCount > 0;
    }
}
