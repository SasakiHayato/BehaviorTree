using UnityEngine;
using BehaviourTree.Execute;

public class ActionMove : BehaviourAction
{
    GameUser _gameUser;
    Enemy _enemy;

    protected override void Setup(GameObject user)
    {
        _gameUser = Object.FindObjectOfType<GameUser>();
        _enemy = user.GetComponent<Enemy>();
    }

    protected override bool Execute()
    {
        Vector3 dir = _gameUser.transform.position - _enemy.transform.position;
        _enemy.MoveDir = dir;

        Debug.Log("Move");

        return true;
    }
}
