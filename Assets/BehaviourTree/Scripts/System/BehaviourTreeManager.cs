using UnityEngine;
using BehaviourTree.Data;
using BehaviourTree.IO;

namespace BehaviourTree
{
    public class BehaviourTreeManager : MonoBehaviour
    {
        void Awake()
        {
            BehaviourTreeIO.DeleteFile();
        }

        void OnDestroy()
        {
            BehaviourTreeMasterData.Dispose();
        }
    }
}