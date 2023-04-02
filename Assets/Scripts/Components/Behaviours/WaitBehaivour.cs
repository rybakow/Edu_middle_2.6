using System;
using System.Collections;
using System.Collections.Generic;
using Components.Interfaces;
using UnityEngine;

public class WaitBehaivour : MonoBehaviour, IBehaviour
{
    private bool _isWaiting;
    
    private Animator _animator;
    
    private void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    
    public float Evaluate()
    {
        return 1f;
    }

    public void Execute()
    {
        Waiting();
        Debug.Log("[" + this.gameObject.name + "] is waiting...");
    }

    private void Waiting()
    {
        _animator.SetBool("isWalking", false);
    }
}
