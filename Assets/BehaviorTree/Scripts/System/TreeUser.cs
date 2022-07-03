using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using BehaviorTree.Data;

public class TreeUser : MonoBehaviour
{
    [SerializeField] List<TreeDataBase> _treeDataList;

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
        if (ModelData.TreeDataBase == null || !ModelData.TreeDataBase.IsAccess)
        {
            Set();
        }
        else
        {
            if (ModelData.TreeData == null)
            {
                Set();
            }
            else
            {
                Run();
            }
        }
    }

    /// <summary>
    /// TreeData�̑}��
    /// </summary>
    void Set()
    {
        _treeModel.Init(ModelData.TreeDataBase);
        _treeModel.OnNext();
    }

    /// <summary>
    /// TreeData�̎��sProcess
    /// </summary>
    void Run()
    {
        if (_treeModel.CheckIsCondition(ModelData.TreeData))
        {
            bool isEnd = _treeModel.SetAction(ModelData.TreeData);

            if (isEnd)
            {
                Set();
            }
        }
        else
        {

        }
    }
}
