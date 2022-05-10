using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    namespace Data
    {
        [CreateAssetMenu (fileName = "ConditionalData")]
        public class Conditional : ScriptableObject
        {
            public ConditionalType Type;

            [SerializeReference, SubclassSelector]
            List<IConditional> Conditionals;

            public List<IConditional> SendConditional => Conditionals;
        }
    }
}