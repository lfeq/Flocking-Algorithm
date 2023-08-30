using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A composite behavior that combines multiple behaviors with corresponding weights.
/// </summary>
[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehaviour : FlockBehaviour {
    [SerializeField] private FlockBehaviour[] behaviours;
    [SerializeField] private float[] weights;

    /// <summary>
    /// Calculates the combined movement direction based on the weighted sum of individual behaviors.
    /// </summary>
    /// <param name="agent">The current agent.</param>
    /// <param name="context">List of nearby agent transforms.</param>
    /// <param name="flock">The FlockManager controlling the flock.</param>
    /// <returns>The calculated movement direction.</returns>
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, FlockManager flock) {
        if (weights.Length != behaviours.Length) {
            throw new UnityException("Data mismatch in " + name);
        }
        Vector2 move = Vector2.zero;
        for (int i = 0; i < behaviours.Length; i++) {
            Vector2 partialMove = behaviours[i].calculateMove(agent, context, flock);
            if (partialMove != Vector2.zero) {
                if (partialMove.sqrMagnitude > weights[i] * weights[i]) {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }
                move += partialMove;
            }
        }
        return move;
    }
}