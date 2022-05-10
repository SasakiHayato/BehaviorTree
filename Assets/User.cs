using UnityEngine;
using BehaviorTree;

public class User : MonoBehaviour
{
    TreeUser _user;

    void Start()
    {
        _user = GetComponent<TreeUser>();
        _user.SetUp();
    }

    void Update()
    {
        _user.Execute();
    }
}
