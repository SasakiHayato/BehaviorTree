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
        /// TreeData���X�V����ۂɌĂ�
        /// AI�����̕ύX
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
        /// TreeDataBase�̎擾
        /// 
        /// ModelData��Null�ł���ΐV�����f�[�^������
        /// Null�łȂ���Ό��݂�ModelData��Ԃ�
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
        /// TreeData�̎擾
        /// 
        /// List�̂͂��߂��珇��TreeData��Ԃ�
        /// �z��O�ɂȂ����ꍇ��Null��Ԃ�
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
                UnityEngine.Debug.Log($"��O");
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
        /// ���s�^�C�v�̌���
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
        /// �n���ꂽDataBase��Null�łȂ����TreeData�̏��������s��
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
