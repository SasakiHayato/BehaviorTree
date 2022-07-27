using UnityEngine;
using BehaviourTree.Data;
using BehaviourTree.IO;

namespace BehaviourTree
{
    public class BehaviourTreeSetting : MonoBehaviour
    {
        void Awake()
        {
            BehaviourTreeIO.Initialize();
        }

        void OnDestroy()
        {
            BehaviourTreeIO.Update();
            BehaviourTreeMasterData.Dispose();
        }
    }
}