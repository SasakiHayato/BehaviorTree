using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree.Execute;
using BehaviorTree.Data;

public class Conditionlimit : Conditional
{
    UserData _userData;
    protected override void SetUp(GameObject user)
    {
        _userData = MasterData.Instance.FindData(user.GetInstanceID());
    }

    protected override bool Try()
    {
        return _userData.IsLimitCondition();
    }

    protected override void Init()
    {
        
    }
}
