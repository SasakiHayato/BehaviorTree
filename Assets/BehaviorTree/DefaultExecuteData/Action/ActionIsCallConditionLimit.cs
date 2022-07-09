using BehaviorTree.Execute;
using BehaviorTree.Data;
using UnityEngine;

/// <summary>
/// ConditionLimitが呼ばれたのち成功したことを通知を行うAI行動
/// </summary>
public class ActionIsCallConditionLimit : Action
{
    BehaviorTreeUserData _userData;
    protected override void Setup(GameObject user)
    {
        _userData = BehaviorTreeMasterData.Instance.FindUserData(user.GetInstanceID());
    }

    protected override bool Execute()
    {
        _userData.SetLimitConditionalCount(_userData.LimitConditionalCount - 1);
        return true;
    }

    protected override void Initialize()
    {
        
    }
}
