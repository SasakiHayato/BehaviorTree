using UnityEngine;
using BehaviorTree.Execute;

/// <summary>
/// 指定時間待たせるAI行動
/// </summary>
public class ActionWait : Action
{
    [SerializeField] float _waitTime;

    float _timer;
    protected override bool Execute()
    {
        _timer += Time.deltaTime;
        return _timer > _waitTime;
    }

    protected override void Initialize()
    {
        _timer = 0;
    }

    protected override void Setup(GameObject user)
    {
        
    }
}
