using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This abstract class defines a base for implementing flocking behaviors in a simulation.
/// Subclasses of this class are expected to provide
/// specific implementations for calculating movement vectors for flocking agents.
/// </summary>
/// <remarks>
/// Flocking behaviors define how individual agents in a flock interact with their neighboring
/// agents and the flock as a whole. Subclasses must implement the calculateMove method
/// to calculate the movement vector for a given agent based on its context and the flock manager.
/// </remarks>
public abstract class FlockBehaviour : ScriptableObject {

    /// <summary>
    /// Calculates the movement vector for the provided agent based on its context and the flock manager.
    /// </summary>
    /// <param name="agent">The agent for which to calculate the movement.</param>
    /// <param name="context">A list of neighboring agent transforms that influence the calculation.</param>
    /// <param name="flock">The flock manager that handles the overall flock behavior.</param>
    /// <returns>A Vector2 representing the desired movement direction for the agent.</returns>
    public abstract Vector2 calculateMove(FlockAgent agent, List<Transform> context, FlockManager flock);
}