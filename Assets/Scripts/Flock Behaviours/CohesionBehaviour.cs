using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A behavior that guides a FlockAgent to move closer to the center of nearby agents.
/// </summary>
[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehaviour : FlockBehaviour {
    [SerializeField] private float agentSmoothTime = 0.5f;

    private Vector2 currentVelocity;

    /// <summary>
    /// Calculates the movement direction for the agent to move closer to the center of nearby agents.
    /// </summary>
    /// <param name="agent">The current agent.</param>
    /// <param name="context">List of nearby agent transforms.</param>
    /// <param name="flock">The FlockManager controlling the flock.</param>
    /// <returns>The calculated movement direction.</returns>
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, FlockManager flock) {
        if (context.Count == 0) {
            return Vector2.zero;
        }
        Vector2 cohesionMove = Vector2.zero;
        foreach (Transform t in context) {
            cohesionMove += (Vector2)t.position;
        }
        cohesionMove /= context.Count;
        cohesionMove -= (Vector2)agent.transform.position;
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
        return cohesionMove;
    }
}