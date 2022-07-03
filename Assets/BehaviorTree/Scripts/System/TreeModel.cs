using System.Collections.Generic;
using UnityEngine;
using System;
using BehaviorTree.Data;

namespace BehaviorTree
{
    public class TreeModel
    {
        public TreeModel(List<TreeDataBase> dataList, TreeUser user)
        {
            _executeList = dataList;
            _user = user;
        }

        List<TreeDataBase> _executeList;
        TreeUser _user;

        int _dataBaseID;
        int _treeID;

        public TreeExecuteType ExecuteType { get; private set; }

        /// <summary>
        /// TreeDataを更新する際に呼ぶ
        /// AI挙動の変更
        /// </summary>
        public void OnNext()
        {
            TreeDataBase dataBase = GetTreeDataBase();
            TreeData treeData = GetTreeData(dataBase);
            SetExecuteType(treeData);
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
            TreeDataBase data = _user.ModelData.TreeDataBase;

            if (data == null)
            {
                try
                {
                    data = _executeList[_dataBaseID];
                    _dataBaseID++;
                }
                catch(Exception)
                {
                    data = _executeList[0];
                    _dataBaseID = 0;
                }
            }

            _user.ModelData.SetTreeDataBase(data);

            return data;
        }

        /// <summary>
        /// TreeDataの取得
        /// 
        /// Listのはじめから順にTreeDataを返す
        /// </summary>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        TreeData GetTreeData(TreeDataBase dataBase)
        {
            TreeData data = null;
            try
            {
                data = dataBase.TreeDataList[_treeID];
                _treeID++;
            }
            catch(Exception)
            {
                _treeID = 0;
            }

            _user.ModelData.SetTreeData(data);

            return data;
        }

        /// <summary>
        /// 実行タイプの決定
        /// </summary>
        /// <param name="treeData"></param>
        void SetExecuteType(TreeData treeData)
        {
            ExecuteType = treeData.TreeExecuteType;
        }

        public bool CheckIsCondition(TreeData treeData)
        {
            return treeData.Condition.IsProcess;
        }

        /// <summary>
        /// IA行動の実行
        /// 
        /// 全てが終了した際にTrueを返す
        /// </summary>
        /// <param name="treeData"></param>
        /// <returns></returns>
        public bool SetAction(TreeData treeData)
        {
             return treeData.Action.IsProcess;
        }

        /// <summary>
        /// TreeDataの初期化を行う
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
                _user.ModelData.SetTreeDataBase(null);
                _user.ModelData.SetTreeData(null);
            }
        }
    }
}
