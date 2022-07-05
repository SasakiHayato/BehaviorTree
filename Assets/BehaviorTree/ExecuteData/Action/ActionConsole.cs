using UnityEngine;
using BehaviorTree.Execute;

public class ActionConsole : Action
{
    [SerializeField] string _txt;
    protected override bool Execute()
    {
        Debug.Log($"Execute\n{_txt}");
        return true;
    }

    protected override void Init()
    {
        Debug.Log("ActionInit");
    }

    protected override void SetUp(GameObject user)
    {
        Debug.Log($"SetUpAction. UserName {user}");
    }
}
