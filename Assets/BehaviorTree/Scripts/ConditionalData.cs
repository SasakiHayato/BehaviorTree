using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    namespace NodeData
    {
        [CreateAssetMenu (fileName = "ConditionalData")]
        public class ConditionalData : ScriptableObject
        {
            public ConditionalType Type;

            [SerializeReference, SubclassSelector]
            List<IConditional> Conditionals;

            public List<IConditional> SendConditional => Conditionals;
        }
    }
}