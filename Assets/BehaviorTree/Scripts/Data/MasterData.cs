using System.Collections.Generic;
using System.Linq;

/// <summary>
/// BehaviorTreeUserのマスターデータ
/// </summary>

namespace BehaviorTree.Data
{
    public class MasterData
    {
        public static MasterData Instance => s_instance;
        static MasterData s_instance = new MasterData();
        MasterData() { }

        Dictionary<int, UserData> _userDic = new Dictionary<int, UserData>();

        public void CreateUser(int instanceID, BehaviorTreeUser user)
        {
            UserData data = new UserData(user);
            _userDic.Add(instanceID, data);
        }

        public void SetLimitConditionalCount(int count, int instanceID)
        {
            UserData user = FindData(instanceID);
            user.SetLimitConditionalCount(count);
        }

        public UserData FindData(int instanceID)
        {
            try
            {
                return _userDic.First(u => u.Key == instanceID).Value;
            }
            catch (System.Exception)
            {
                UnityEngine.Debug.Log("NothingData Return => Null");
                return null;
            }
        }

        public void DeleteUser(int instanceID)
        {
            _userDic.Remove(instanceID);
        }
    }
}