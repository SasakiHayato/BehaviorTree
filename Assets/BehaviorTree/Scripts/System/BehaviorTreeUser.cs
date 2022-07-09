using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using BehaviorTree.Data;

/// <summary>
/// BehaviorTreeを使用するObjectにアタッチするクラス
/// AI挙動の操作を行う
/// </summary>

public class BehaviorTreeUser : MonoBehaviour
{
    [SerializeField] Transform _offset;
    [SerializeField] int _limitConditionalCount;
    [SerializeField] List<TreeDataBase> _treeDataList;

    TreeModel _treeModel;
    ModelData ModelData => _treeModel.ModelData;
    
    void Start()
    {
        BehaviorTreeMasterData.Instance.CreateUser(GetInstanceID(), this, _offset);
        BehaviorTreeMasterData.Instance
            .FindUserData(GetInstanceID())
            .SetLimitConditionalCount(_limitConditionalCount);

        _treeDataList
            .ForEach(d => d.NodeList
            .ForEach(n => 
            {
                n.SetUp();
                n.SetNodeUser(gameObject);
            }));

        _treeModel = new TreeModel(_treeDataList);
    }

    void Update()
    {
        if (ModelData.TreeDataBase == null || 
            !ModelData.TreeDataBase.IsAccess || 
            ModelData.ExecuteData == null)
        {
            Set();
        }
        else
        {
            if (Execute())
            {
                switch (ModelData.TreeData.TreeType)
                {
                    case ConditionType.Selector: Set(); break;
                    case ConditionType.Sequence: _treeModel.OnNext(); break;
                }
            }
        }
    }

    /// <summary>
    /// TreeDataの挿入
    /// </summary>
    void Set()
    {
        _treeModel.Init(ModelData.TreeDataBase);
        _treeModel.OnNext();
    }

    /// <summary>
    /// TreeDataの実行Process
    /// </summary>
    bool Execute()
    {
        if (_treeModel.CheckIsCondition(ModelData.ExecuteData))
        {
            // Note. 行動が全て終了した時点でTrueを返す
            if (ModelData.ExecuteData.Action.IsProcess)
            {
                return true;
            }
        }
        else
        {
            return true;
        }

        return false;
    }

    private void OnDestroy()
    {
        BehaviorTreeMasterData.Instance.DeleteUser(GetInstanceID());
    }
}
