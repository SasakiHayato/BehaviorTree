using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using BehaviorTree.Data;

public class TreeUser : MonoBehaviour
{
    [SerializeField] List<TreeDataBase> _treeDataList;

    bool _isTask = false;
    bool _isCall = false;

    TreeModel _treeModel;
    public ModelData ModelData { get; private set; }
    
    void Start()
    {
        _treeDataList
            .ForEach(d => d.NodeList
            .ForEach(n => 
            {
                n.SetUp();
                n.SetNodeUser(gameObject);
            }));

        _treeModel = new TreeModel(_treeDataList, this);
        ModelData = new ModelData();
    }

    void Update()
    {
        if (ModelData.TreeDataBase == null || !ModelData.TreeDataBase.IsAccess || ModelData.TreeData == null)
        {
            Set();
        }
        else
        {
            Execute();
        }
    }

    /// <summary>
    /// TreeDataÇÃë}ì¸
    /// </summary>
    void Set()
    {
        _treeModel.Init(ModelData.TreeDataBase);
        _treeModel.OnNext();
    }

    /// <summary>
    /// TreeDataÇÃé¿çsProcess
    /// </summary>
    void Execute()
    {
        if (_isTask)
        {
            RunTask();
            return;
        }
        else
        {
            switch (_treeModel.ExecuteType)
            {
                case TreeExecuteType.Update:

                    _isCall = false;
                    RunUpdate();

                    break;
                case TreeExecuteType.Task: _isTask = true; break;
            }
        }
    }

    void RunUpdate()
    {
        if (_treeModel.CheckIsCondition(ModelData.TreeData))
        {
            _isTask = false;

            bool isEnd = _treeModel.SetAction(ModelData.TreeData);

            if (isEnd)
            {
                _treeModel.SetNextTreeData(ModelData.TreeDataBase);
            }
        }
    }

    void RunTask()
    {
        if (_treeModel.CheckIsCondition(ModelData.TreeData) || _isCall)
        {
            _isCall = true;
            bool isEnd = _treeModel.SetAction(ModelData.TreeData);

            if (isEnd)
            {
                _treeModel.SetNextTreeData(ModelData.TreeDataBase);

                if (ModelData.TreeData == null)
                {
                    _isTask = false;
                }
            }
        }
    }
}
