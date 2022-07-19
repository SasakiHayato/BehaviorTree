using System.Collections.Generic;
using System;
using UnityEngine;
using BehaviourTree.Data;

namespace BehaviourTree
{
    /// <summary>
    /// BehaviorTreeを使用するObjectにアタッチするクラス
    /// AI挙動の操作を行う
    /// </summary>
    public class BehaviorTreeUser : MonoBehaviour
    {
        [SerializeField] string _path;
        [SerializeField] bool _runUpdate = true;
        [SerializeField] Transform _offset;
        [SerializeField] int _limitConditionalCount;
        [SerializeField] List<TreeDataBase> _treeDataList;

        bool _runRequest = true;

        TreeModel _treeModel;
        ModelData ModelData => _treeModel.ModelData;

        /// <summary>
        /// 任意のタイミングでTreeModelを呼び出す
        /// </summary>
        public Action OnNext { get; private set; }

        public int UserID { get; private set; }

        void Start()
        {
            SetUserData();
            SetModelData();
            SetAction();
        }

        void SetUserData()
        {
            Transform offset = _offset;

            if (offset == null)
            {
                offset = transform;
            }

            if (_path == "")
            {
                _path = BehaviorTreeMasterData.CreateUserPath();
                Debug.LogWarning($"{gameObject.name} has not UserPath. So Create it. PathName is => {_path}.");
            }

            UserID = BehaviorTreeMasterData.CreateUserID();

            BehaviorTreeMasterData.Instance.CreateUser(UserID, _path, this, offset);

            BehaviorTreeMasterData.Instance
                .FindUserData(UserID)
                .SetLimitConditionalCount(_limitConditionalCount);
        }

        void SetModelData()
        {
            _treeDataList
                .ForEach(d => d.NodeList
                .ForEach(n =>
                {
                    n.SetNodeUser(gameObject);
                    n.SetUp();
                }));

            _treeModel = new TreeModel(_treeDataList);
        }

        void SetAction()
        {
            OnNext += () =>
            {
                if (ModelData.TreeDataBase == null ||
                !ModelData.TreeDataBase.IsAccess ||
                ModelData.ExecuteData == null)
                {
                    Set();
                }
            };

            OnNext += () =>
            {
                if (Execute())
                {
                    switch (ModelData.TreeData.TreeType)
                    {
                        case ConditionType.Selector: Set(); break;
                        case ConditionType.Sequence: _treeModel.OnNext(); break;
                    }
                }
            };
        }

        void Update()
        {
            if (_runUpdate && _runRequest)
            {
                Run();
            }
        }

        void Run()
        {
            if (ModelData.TreeDataBase == null ||
                !ModelData.TreeDataBase.IsAccess ||
                ModelData.ExecuteData == null)
            {
                Debug.Log($"ExecuteData_{ModelData.ExecuteData}");
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

        public void SetRunRequest(bool isRun) => _runRequest = isRun;

        private void OnDestroy()
        {
            BehaviorTreeMasterData.Instance.DeleteUser(UserID);
        }
    }
}
