using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages a flock of agents within a simulation environment. It controls the behavior
/// of the flock by specifying agent properties and their interactions based on a provided flock behavior.
/// </summary>
/// <remarks>
/// This class manages a flock of agents by updating their behavior according to the provided
/// FlockBehaviour. It calculates agent movement, enforces speed limits, and manages interaction
/// with nearby objects. The flocking behavior is influenced by the chosen FlockBehaviour implementation.
/// </remarks>
public class FlockManager : MonoBehaviour {
    [SerializeField] private FlockAgent agentPrefab;
    [SerializeField] private FlockBehaviour agentBehaviour;
    [Range(10, 500), SerializeField] private int startingFlockCount;
    [Range(1f, 100f), SerializeField] private float driveFactor = 10f;
    [Range(1f, 100f), SerializeField] private float maxSpeed = 5f;
    [Range(1f, 100f), SerializeField] private float neighbourRadius = 1.5f;
    [Range(0f, 1f), SerializeField] private float avoidanceRadiusMultiplier = 0.5f;

    private List<FlockAgent> agents = new List<FlockAgent>();
    private const float agentDensity = 0.08f;
    private float squareMaxSpeed;
    private float squareNeighbourRadius;
    private float squareAvoidanceRadius;

    /// <summary>
    /// Gets the square of the avoidance radius used for collision avoidance calculations.
    /// </summary>
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    private void Start() {
        // Pre-calculate squared values for efficiency in comparisons.
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        // Initialize the flock by instantiating agents and assigning them initial positions.
        for (int i = 0; i < startingFlockCount; i++) {
            FlockAgent newAgent = Instantiate(agentPrefab, Random.insideUnitCircle * startingFlockCount * agentDensity, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
        }
    }

    private void Update() {
        // Iterate through all agents, calculate their movement, and apply updates.
        foreach (FlockAgent agent in agents) {
            List<Transform> context = GetNearbyObjects(agent);
            //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
            Vector2 move = agentBehaviour.calculateMove(agent, context, this);
            move *= driveFactor;
            // Limit the agent's speed if it exceeds the maximum allowed speed.
            if (move.sqrMagnitude >= squareMaxSpeed) {
                move = move.normalized * maxSpeed;
            }
            agent.move(move);
        }
    }

    /// <summary>
    /// Retrieves a list of neighboring object transforms around the specified <paramref name="agent"/>
    /// within a certain radius. Excludes the agent's own collider from the list.
    /// </summary>
    /// <param name="agent">The FlockAgent for which to find nearby objects.</param>
    /// <returns>A list of Transform components representing nearby objects.</returns>
    private List<Transform> GetNearbyObjects(FlockAgent agent) {
        List<Transform> context = new List<Transform>();
        // Gather neighboring objects within the defined radius.
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
        foreach (Collider2D c in contextColliders) {
            if (c == agent.AgentCollider) continue;
            context.Add(c.transform);
        }
        return context;
    }
}