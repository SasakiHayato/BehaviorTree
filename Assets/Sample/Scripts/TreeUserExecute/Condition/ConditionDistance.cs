using UnityEngine;
using BehaviourTree.Execute;

public class ConditionDistance : BehaviourConditional
{
    [SerializeField] float _findDistance;

    Transform _user;
    GameUser _gameUser;

    protected override void Setup(GameObject user)
    {
        _user = user.transform;
        _gameUser = Object.FindObjectOfType<GameUser>();
    }

    protected override bool Try()
    {
        float dist = Vector2.Distance(_user.position, _gameUser.transform.position);

        return _findDistance > dist;
    }
}
