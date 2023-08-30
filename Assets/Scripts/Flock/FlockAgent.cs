using UnityEngine;

/// <summary>
/// This class represents a flocking agent in a simulation. The class provides
/// functionality for controlling the movement of the agent and managing its collision.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour {
    private Collider2D agentCollider;

    /// <summary>
    /// Gets the Collider2D component attached to the agent.
    /// </summary>
    public Collider2D AgentCollider { get { return agentCollider; } }

    private void Start() {
        agentCollider = GetComponent<Collider2D>();
    }

    /// <summary>
    /// Moves the agent based on the provided velocity vector. It orients the agent's
    /// forward direction to match the velocity direction and updates its position
    /// according to the velocity and deltaTime.
    /// </summary>
    /// <param name="velocity">The desired movement velocity of the agent.</param>
    public void move(Vector2 velocity) {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}