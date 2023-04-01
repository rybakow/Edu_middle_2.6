using System.Collections;
using System.Collections.Generic;
using Components.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkBehaivour : MonoBehaviour, IBehaviour
{
    public float Evaluate()
    {
        List<Collider> collisions = this.GetComponent<CollisionAbility>().Collisions;
        
        foreach (var coll in collisions)
        {
            var player = coll?.gameObject?.GetComponent<CharacterHealth>();

            if (player != null)
            {
                Debug.Log("WalkBeh - вижу игрока");
                return 2f;
            }
        }
        
        return 0f;
    }

    public void Execute()
    {
        Debug.Log("Zombie is walking...");
    }
}
