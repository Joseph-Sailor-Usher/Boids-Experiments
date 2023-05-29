using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardToBitsTutorial 
{
    [CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
    public class SameFlockFilter : ContextFilter
    {
        public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            List<Transform> filteredContext = new List<Transform>();

            foreach(Transform item in original) 
            {
                FlockAgent itemAgent = item.GetComponent<FlockAgent>();
                if(itemAgent != null && itemAgent.AgentFlock == agent.AgentFlock) 
                {
                    filteredContext.Add(item);
                }
            }

            return filteredContext;
        }
    }
}
