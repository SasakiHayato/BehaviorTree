using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using UnityEngine.UI;

namespace BehaviorTree
{
    public class TreeUser : MonoBehaviour
    {
        [SerializeField] Text _text;
        [SerializeField] string _dataPath;
        BaseGraph _baseGraph;

        void Start()
        {
            _baseGraph = Resources.Load<BaseGraph>(_dataPath);
            Debug.Log(_baseGraph);
        }

        void Update()
        {
            //_baseGraph.nodes[0].OnProcess();
            //_text.text = _baseGraph.nodes[0].GetType().ToString();
        }
    }
}
