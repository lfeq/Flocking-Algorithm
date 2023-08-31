# Flocking-Algorithm

This repository contains the code for a flock simulation. The simulation consists of a number of agents that move around the screen, following certain rules. The rules are implemented as "flock behaviours" and can be added or removed to change the behaviour of the agents.

### Code Structure

The code is organized into a number of scripts:

* **FlockAgent.cs**: This script is attached to each agent in the simulation. It contains the agent's movement logic and handles collision with other agents.
* **FlockBehaviour.cs**: This abstract class defines the interface for flock behaviours. Subclasses of this class implement the specific behaviour of each flock.
* **FlockManager.cs**: This script manages the flock of agents. It controls the behaviour of the flock by specifying agent properties and their interactions based on a provided flock behaviour.
* **AlligmentBehaviour.cs**: This behaviour aligns the movement of an agent with the average direction of nearby agents.
* **AvoidanceBehaviour.cs**: This behaviour guides an agent to avoid colliding with nearby agents.
* **CohesionBehaviour.cs**: This behaviour guides an agent to move closer to the center of nearby agents.
* **CompositeBehaviour.cs**: This behaviour combines multiple behaviours with corresponding weights.
* **StayInRadiusBehavior.cs**: This behaviour keeps agents within a specified radius from a center point.

### How to Use

To use the simulation, simply import the project into Unity and press play. You can change the behaviour of the agents by adding or removing flock behaviours from the FlockManager.
