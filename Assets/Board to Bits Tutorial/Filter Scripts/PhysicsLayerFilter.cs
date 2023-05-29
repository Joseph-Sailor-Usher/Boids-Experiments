using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardToBitsTutorial
{
    [CreateAssetMenu(menuName = "Flock/Filter/Physics Layer")]
    public class PhysicsLayerFilter : ContextFilter
    {
        public LayerMask mask;

        public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            List<Transform> filteredContext = new List<Transform>();

            foreach(Transform item in original) 
            {
                if(mask == (mask | (1 << item.gameObject.layer))) 
                {
                    filteredContext.Add(item);
                }
            }

            return filteredContext;
        }
    }
}
