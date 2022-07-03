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
        /// TreeData���X�V����ۂɌĂ�
        /// AI�����̕ύX
        /// </summary>
        public void OnNext()
        {
            TreeDataBase dataBase = GetTreeDataBase();
            TreeData treeData = GetTreeData(dataBase);
            SetExecuteType(treeData);
        }

        /// <summary>
        /// TreeDataBase�̎擾
        /// 
        /// ModelData��Null�ł���ΐV�����f�[�^������
        /// Null�łȂ���Ό��݂�ModelData��Ԃ�
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
        /// TreeData�̎擾
        /// 
        /// List�̂͂��߂��珇��TreeData��Ԃ�
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
        /// ���s�^�C�v�̌���
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
        /// IA�s���̎��s
        /// 
        /// �S�Ă��I�������ۂ�True��Ԃ�
        /// </summary>
        /// <param name="treeData"></param>
        /// <returns></returns>
        public bool SetAction(TreeData treeData)
        {
             return treeData.Action.IsProcess;
        }

        /// <summary>
        /// TreeData�̏��������s��
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
