using UnityEngine;
using BehaviourTree.Execute;

public class ActionIdle : BehaviourAction
{
    Enemy _enemy;
    protected override void Setup(GameObject user)
    {
        _enemy = user.GetComponent<Enemy>();
    }

    protected override bool Execute()
    {
        _enemy.MoveDir = Vector2.zero;
        return true;
    }
}
