using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardToBitsTutorial 
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Stay Within Radius")]
    public class StayWithinRadius : FlockBehavior
    {
        public Vector2 center;
        public float radius = 15f;
        
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            Vector2 centerOffset = center - (Vector2)agent.transform.position;
            float t = centerOffset.magnitude / radius;

            if(t < 0.9f)
            {
                return Vector2.zero;
            }

            return centerOffset * t * t;
        }
    }
}
