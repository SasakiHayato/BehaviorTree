using System.Collections.Generic;
using System;
using System.Linq;
using BehaviorTree.Data;

namespace BehaviorTree
{
    public class TreeModel
    {
        public TreeModel(List<TreeDataBase> dataList)
        {
            int id = 0;

            foreach (TreeDataBase data in dataList)
            {
                if (data.HasCondition)
                {
                    data.ID = id;
                }
                else
                {
                    data.ID = 100 + id;
                }

                id++;
            }

            _executeList = dataList.OrderBy(d => d.ID).ToList();
           
            ModelData = new ModelData();
        }

        public ModelData ModelData { get; private set; }

        List<TreeDataBase> _executeList;
        
        int _treeID;
        int _saveDataBaseID = int.MinValue;
        bool _isTaskCall = false;

        TreeExecuteType _executeType;

        /// <summary>
        /// TreeDataを更新する際に呼ぶ
        /// AI挙動の変更
        /// </summary>
        public void OnNext()
        {
            TreeDataBase dataBase = GetTreeDataBase();

            if (!CheckDataBaseID(dataBase))
            {
                _saveDataBaseID = dataBase.ID;
                _treeID = 0;
            }

            TreeData treeData = GetTreeData(dataBase);

            ModelData.SetTreeDataBase(dataBase);
            ModelData.SetTreeData(treeData);

            SetExecuteType(treeData);

            _isTaskCall = false;
        }

        /// <summary>
        /// TreeDataBaseの取得
        /// 
        /// ModelDataがNullであれば新しくデータを入れる
        /// Nullでなければ現在のModelDataを返す
        /// </summary>
        /// <returns></returns>
        TreeDataBase GetTreeDataBase()
        {
            TreeDataBase data = ModelData.TreeDataBase;

            if (data == null)
            {
                data = _executeList.First(e => e.IsAccess);
            }

            return data;
        }

        /// <summary>
        /// TreeDataの取得
        /// 
        /// Listのはじめから順にTreeDataを返す
        /// 配列外になった場合にNullを返す
        /// </summary>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        TreeData GetTreeData(TreeDataBase dataBase)
        {
            TreeData data;

            try
            {
                data = dataBase.TreeDataList[_treeID];
                UnityEngine.Debug.Log($"aaa{_treeID}");
                _treeID++;
            }
            catch(Exception)
            {
                data = null;
                UnityEngine.Debug.Log($"例外");
                _treeID = 0;
            }

            return data;
        }

        bool CheckDataBaseID(TreeDataBase dataBase)
        {
            if (_saveDataBaseID == int.MinValue)
            {
                _saveDataBaseID = dataBase.ID;
                return false;
            }
            else
            {
                return _saveDataBaseID == dataBase.ID;
            }
        }

        /// <summary>
        /// 実行タイプの決定
        /// </summary>
        /// <param name="treeData"></param>
        void SetExecuteType(TreeData treeData)
        {
            if (treeData == null)
            {
                _executeType = TreeExecuteType.Update;
            }
            else
            {
                _executeType = treeData.TreeExecuteType;
            }
        }

        public bool CheckIsCondition(TreeData treeData)
        {
            bool isProcess = treeData.Condition.IsProcess;

            switch (_executeType)
            {
                case TreeExecuteType.Update: return isProcess;

                case TreeExecuteType.Task:
                    
                    if (isProcess && !_isTaskCall)
                    {
                        _isTaskCall = true;
                    }

                    return _isTaskCall;

                default: return false;
            }
        }

        public bool SetAction(TreeData treeData)
        {
             return treeData.Action.IsProcess;
        }

        /// <summary>
        /// 渡されたDataBaseがNullでなければTreeDataの初期化を行う
        /// </summary>
        /// <param name="dataBase"></param>
        public void Init(TreeDataBase dataBase)
        {
            if (dataBase == null)
            {
                return;
            }
            else
            {
                dataBase.TreeDataList.ForEach(d => d.Action.Init());

                ModelData.SetTreeDataBase(null);
                ModelData.SetTreeData(null);

                _treeID = 0;
                _saveDataBaseID = 0;
            }
        }
    }
}
