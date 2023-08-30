using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A behavior that guides a FlockAgent to avoid colliding with nearby agents.
/// </summary>
[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehaviour : FlockBehaviour {

    /// <summary>
    /// Calculates the movement direction for the agent to avoid colliding with nearby agents.
    /// </summary>
    /// <param name="agent">The current agent.</param>
    /// <param name="context">List of nearby agent transforms.</param>
    /// <param name="flock">The FlockManager controlling the flock.</param>
    /// <returns>The calculated movement direction.</returns>
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, FlockManager flock) {
        if (context.Count == 0) {
            return agent.transform.up;
        }
        Vector2 avoidanceMove = Vector2.zero;
        int neighborsToAvoid = 0;
        foreach (Transform t in context) {
            if (Vector2.SqrMagnitude(t.position - agent.transform.position) < flock.SquareAvoidanceRadius) {
                neighborsToAvoid++;
                avoidanceMove += (Vector2)(agent.transform.position - t.position);
            }
        }
        if (neighborsToAvoid > 0) {
            avoidanceMove /= neighborsToAvoid;
        }
        return avoidanceMove;
    }
}