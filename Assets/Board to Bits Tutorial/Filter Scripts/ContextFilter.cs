using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardToBitsTutorial
{
    public class ContextFilter : ScriptableObject
    {
        public virtual List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            return original;
        }
    }
}
