using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A behavior that aligns the movement of a FlockAgent with the average direction of nearby agents.
/// </summary>
[CreateAssetMenu(menuName = "Flock/Behavior/Alligment")]
public class AlligmentBehaviour : FlockBehaviour {

    /// <summary>
    /// Calculates the movement direction for the agent based on alignment with nearby agents.
    /// </summary>
    /// <param name="agent">The current agent.</param>
    /// <param name="context">List of nearby agent transforms.</param>
    /// <param name="flock">The FlockManager controlling the flock.</param>
    /// <returns>The calculated movement direction.</returns>
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, FlockManager flock) {
        if (context.Count == 0) {
            return agent.transform.up;
        }
        Vector2 alligmentMove = Vector2.zero;
        foreach (Transform t in context) {
            alligmentMove += (Vector2)t.up;
        }
        alligmentMove /= context.Count;
        return alligmentMove;
    }
}