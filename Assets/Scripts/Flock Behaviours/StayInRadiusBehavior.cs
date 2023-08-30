using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A behavior that keeps agents within a specified radius from a center point.
/// </summary>
[CreateAssetMenu(menuName = "Flock/Behavior/Stay in Radius")]
public class StayInRadiusBehavior : FlockBehaviour {
    [SerializeField] private Vector2 center = Vector2.zero;
    [SerializeField] private float radius = 15f;

    /// <summary>
    /// Calculates a movement offset that keeps the agent within the specified radius from the center.
    /// </summary>
    /// <param name="agent">The current agent.</param>
    /// <param name="context">List of nearby agent transforms.</param>
    /// <param name="flock">The FlockManager controlling the flock.</param>
    /// <returns>The calculated movement offset.</returns>
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, FlockManager flock) {
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.9f) {
            return Vector2.zero;
        }
        return centerOffset * t * t;
    }
}