using System.Collections.Generic;
using System;
using System.Linq;
using BehaviorTree.Data;

namespace BehaviorTree
{
    public class TreeModel
    {
        public TreeModel(List<TreeDataBase> dataList, TreeUser user)
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
            _user = user;
        }

        List<TreeDataBase> _executeList;
        TreeUser _user;

        int _treeID;

        int _saveDataBaseID = int.MinValue;

        public TreeExecuteType ExecuteType { get; private set; }

        /// <summary>
        /// TreeData���X�V����ۂɌĂ�
        /// AI�����̕ύX
        /// </summary>
        public void OnNext()
        {
            TreeDataBase dataBase = GetTreeDataBase();

            if (!CheckID(dataBase))
            {
                _treeID = 0;
            }

            TreeData treeData = GetTreeData(dataBase);

            _user.ModelData.SetTreeDataBase(dataBase);
            _user.ModelData.SetTreeData(treeData);

            SetExecuteType(treeData);
        }

        public void SetNextTreeData(TreeDataBase dataBase)
        {
            TreeData treeData = GetTreeData(dataBase);

            _user.ModelData.SetTreeData(treeData);
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
                data = _executeList.First(e => e.IsAccess);
            }

            return data;
        }

        /// <summary>
        /// TreeData�̎擾
        /// 
        /// List�̂͂��߂��珇��TreeData��Ԃ�
        /// �z��O�ɂȂ����ꍇ��Null��Ԃ�
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

            return data;
        }

        bool CheckID(TreeDataBase dataBase)
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

                _treeID = 0;
                _saveDataBaseID = 0;
            }
        }
    }
}
