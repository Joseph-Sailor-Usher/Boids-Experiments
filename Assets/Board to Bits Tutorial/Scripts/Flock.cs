using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace BoardToBitsTutorial 
{
    public class Flock : MonoBehaviour
    {
        //The prefab of the agent
        public FlockAgent agentPrefab;
        
        //The list of agents
        private List<FlockAgent> agents = new List<FlockAgent>();
        
        //The behavior that the agents will follow
        public FlockBehavior behavior;
        
        //The number of agents in the flock
        [Range(10, 500)]
        public int startingCount = 250;
        
        //The density of the agents in the flock
        private const float AgentDensity = 0.08f;

        //The default rate at which the agents will move
        [Range(1f, 100f)]
        public float driveFactor = 10f;

        //The maximum speed of the agents
        [Range(1f, 100f)]
        public float maxSpeed = 5f;
        
        //The radius of the neighborhood
        [Range(1f, 10f)]
        public float neighborRadius = 1.5f;
        
        //The radius of the avoidance
        [Range(0f, 1f)]
        public float avoidanceRadiusMultiplier = 0.5f;

        private float squareMaxSpeed;
        private float squareNeighborRadius;
        private float squareAvoidanceRadius;
        public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

        private void Start()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
            squareNeighborRadius = neighborRadius * neighborRadius;
            squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

            for(int i = 0; i < startingCount; i++)
            {
                FlockAgent newAgent = Instantiate(
                    agentPrefab,
                    Random.insideUnitCircle * startingCount * AgentDensity,
                    Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                    transform
                );
                newAgent.name = "Agent " + i;
                //newAgent.Initialize(this);
                agents.Add(newAgent);
            }
        }

        private void Update() 
        {
            foreach(FlockAgent agent in agents)
            {
                List<Transform> context = GetNearbyObjects(agent);
                //For debug only
                agent.GetComponentInChildren<Image>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
                //Vector2 move = behavior.CalculateMove(agent, context, this);
                //move *= driveFactor;
                //if(move.sqrMagnitude > squareMaxSpeed)
                //{
                //    move = move.normalized * maxSpeed;
                //}
                //agent.Move(move);
            }
        }

        private List<Transform> GetNearbyObjects(FlockAgent agent) 
        {
            List<Transform> context = new List<Transform>();
            Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
            foreach(Collider2D c in contextColliders)
            {
                if(c != agent.AgentCollider)
                {
                    context.Add(c.transform);
                }
            }
            return context;
        }
    }
}
