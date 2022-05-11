using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;

namespace BehaviorTree
{
    public class TreeUser : MonoBehaviour
    {
        [SerializeField] string _dataPath;
        BaseGraph _baseGraph;

        void Start()
        {
            _baseGraph = Resources.Load<BaseGraph>(_dataPath);
            Debug.Log(_baseGraph);
        }

        void Update()
        {
            Debug.Log(_baseGraph.nodes.Count);
        }
    }
}
