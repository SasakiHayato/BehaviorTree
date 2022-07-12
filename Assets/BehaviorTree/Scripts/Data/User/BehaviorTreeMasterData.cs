using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// BehaviorTreeUserのマスターデータ
/// </summary>

namespace BehaviorTree.Data
{
    public class BehaviorTreeMasterData
    {
        public static BehaviorTreeMasterData Instance => s_instance;
        static BehaviorTreeMasterData s_instance = new BehaviorTreeMasterData();

        Dictionary<int, BehaviorTreeUserData> _userDic = new Dictionary<int, BehaviorTreeUserData>();

        public void CreateUser(int instanceID, BehaviorTreeUser user, Transform offset)
        {
            BehaviorTreeUserData data = new BehaviorTreeUserData(user, offset);
            _userDic.Add(instanceID, data);
        }

        public BehaviorTreeUserData FindUserData(int instanceID)
        {
            try
            {
                return _userDic.First(u => u.Key == instanceID).Value;
            }
            catch (Exception)
            {
                Debug.Log($"NothingData. FindID{instanceID}.  Return => Null");
                return null;
            }
        }

        public List<BehaviorTreeUserData> FindUserDataAll()
        {
            List<BehaviorTreeUserData> dataList = new List<BehaviorTreeUserData>();

            foreach (KeyValuePair<int, BehaviorTreeUserData> data in _userDic)
            {
                dataList.Add(data.Value);
            }

            return dataList;
        }

        public void DeleteUser(int instanceID)
        {
            if (_userDic.Count <= 0)
            {
                return;
            }

            _userDic.Remove(instanceID);
        }

        public static void DisposeDictionary()
        {
            Instance._userDic = new Dictionary<int, BehaviorTreeUserData>();
        }
    }
}