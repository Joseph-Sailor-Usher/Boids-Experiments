using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardToBitsTutorial
{
    public abstract class FilteredFlockBehavior : FlockBehavior
    {
        public ContextFilter filter;
    }
}
