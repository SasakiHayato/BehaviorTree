using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using BehaviorTree.Data;

public class TreeUser : MonoBehaviour
{
    [SerializeField] List<TreeDataBase> _dataList;

    TreeModel _model;

    void Start()
    {
        _model = new TreeModel();
    }

    void Update()
    {
        
    }
}
