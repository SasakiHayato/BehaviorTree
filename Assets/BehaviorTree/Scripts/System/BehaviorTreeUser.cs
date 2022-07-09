using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using BehaviorTree.Data;

/// <summary>
/// BehaviorTree���g�p����Object�ɃA�^�b�`����N���X
/// AI�����̑�����s��
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
    bool Execute()
    {
        if (_treeModel.CheckIsCondition(ModelData.ExecuteData))
        {
            // Note. �s�����S�ďI���������_��True��Ԃ�
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
