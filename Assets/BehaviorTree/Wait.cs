using UnityEngine;
using BehaviorTree.Execute;

public class Wait : Condition
{
    protected override void Init(GameObject user)
    {
        
    }

    protected override bool Try()
    {
        return true;
    }
}
