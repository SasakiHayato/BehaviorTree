using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    namespace Data
    {
        [CreateAssetMenu(fileName = "ActionData")]
        public class Action : ScriptableObject
        {
            public ActionType ActionType;

            [SerializeReference, SubclassSelector]
            List<IAction> Actions;

            public List<IAction> SendAction => Actions;
        }
    }
}
