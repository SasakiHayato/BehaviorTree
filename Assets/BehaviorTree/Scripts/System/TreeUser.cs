using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using BehaviorTree.Data;

public class TreeUser : MonoBehaviour
{
    [SerializeField] List<TreeDataBase> _treeDataList;

    bool _isTask = false;

    TreeModel _treeModel;
    public ModelData ModelData { get; private set; }
    
    void Start()
    {
        _treeDataList
            .ForEach(d => d.NodeList
            .ForEach(n => n.SetNodeUser(gameObject)));

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
            Run();
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
    void Run()
    {
        switch (_treeModel.ExecuteType)
        {
            case TreeExecuteType.Update: Normal(); break;
            case TreeExecuteType.Task: Task(); break;
        }
    }

    void Normal()
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

    void Task()
    {
        if (_treeModel.CheckIsCondition(ModelData.TreeData) || _isTask)
        {
            _isTask = true;
            bool isEnd = _treeModel.SetAction(ModelData.TreeData);

            if (isEnd)
            {
                _treeModel.SetNextTreeData(ModelData.TreeDataBase);
            }
        }
    }
}
