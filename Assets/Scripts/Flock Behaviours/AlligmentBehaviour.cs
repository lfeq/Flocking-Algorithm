using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alligment")]
public class AlligmentBehaviour : FlockBehaviour {

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