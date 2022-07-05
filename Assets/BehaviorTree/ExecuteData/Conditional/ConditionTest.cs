using UnityEngine;
using BehaviorTree.Execute;

public class ConditionTest : Conditional
{
    [SerializeField] bool _isAccess;
    protected override void Init()
    {
        
    }

    protected override void SetUp(GameObject user)
    {
        
    }

    protected override bool Try()
    {
        return _isAccess;
    }
}
