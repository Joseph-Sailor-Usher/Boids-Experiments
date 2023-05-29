using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardToBitsTutorial 
{
    public abstract class FlockBehavior : ScriptableObject
    {
        public abstract Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock);
    }
}
