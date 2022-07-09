using BehaviorTree.Execute;
using BehaviorTree.Data;
using UnityEngine;

public class ActionIsCallConditionLimit : Action
{
    UserData _userData;
    protected override void SetUp(GameObject user)
    {
        _userData = MasterData.Instance.FindData(user.GetInstanceID());
    }

    protected override bool Execute()
    {
        _userData.SetLimitConditionalCount(_userData.LimitConditionalCount - 1);
        return true;
    }

    protected override void Init()
    {
        
    }
}
