using System.Collections;
using System.Collections.Generic;
using Components.Interfaces;
using UnityEngine;

public class WaitBehaivour : MonoBehaviour, IBehaviour
{
    public float Evaluate()
    {
        return 1f;
    }

    public void Execute()
    {
        Debug.Log("Zombie is waiting...");
    }
}
