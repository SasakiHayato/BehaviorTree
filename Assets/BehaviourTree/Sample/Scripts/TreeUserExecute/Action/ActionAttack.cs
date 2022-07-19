using UnityEngine;
using BehaviourTree.Execute;

public class ActionAttack : BehaviourAction
{
    [SerializeField] float _rotateSpeed;

    Enemy _enemy;

    float _rotate;

    protected override void Setup(GameObject user)
    {
        _enemy = user.GetComponent<Enemy>();
        _rotate = 0;
    }

    protected override bool Execute()
    {
        _rotate += Time.deltaTime * _rotateSpeed;

        _enemy.transform.rotation = Quaternion.Euler(0, 0, _rotate);
        
        return _rotate > 360;
    }

    protected override void Initialize()
    {
        _rotate = 0;
        _enemy.transform.rotation = Quaternion.identity;
    }
}
