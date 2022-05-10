using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    [CreateAssetMenu (fileName = "ActionData")]
    public class ActionData : ScriptableObject
    {
        public ActionType ActionType;
        
        [SerializeReference, SubclassSelector]
        List<IAction> Actions;

        public List<IAction> SendAction => Actions;
    }
}
