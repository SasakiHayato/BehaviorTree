using UnityEngine;
using BehaviorTree.Execute;
using BehaviorTree.Data;

/// <summary>
/// ‰ñ”§ŒÀ‚Ì‚ ‚éAIs“®‚É‚Â‚¯‚éğŒ
/// </summary>
public class Conditionlimit : Conditional
{
    BehaviorTreeUserData _userData;
    protected override void Setup(GameObject user)
    {
        _userData = BehaviorTreeMasterData.Instance.FindUserData(user.GetInstanceID());
    }

    protected override bool Try()
    {
        return _userData.IsLimitCondition();
    }

    protected override void Initialize()
    {
        
    }
}
