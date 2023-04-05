using System;
using System.Collections;
using System.Collections.Generic;
using Components.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkBehaivour : MonoBehaviour, IBehaviour
{
    public GameObject ParentObject;
    public float Speed;

    private bool _isWalking;
    
    private Animator _animator;
    private GameObject _target;

    private void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        Walking();
    }

    public float Evaluate()
    {
        List<Collider> collisions = this.GetComponent<CollisionAbility>().Collisions;
        
        foreach (var coll in collisions)
        {
            var player = coll?.gameObject?.GetComponent<CharacterHealth>();

            if (player != null)
            {
                _target = player.gameObject;
                return 2f;
            }
                
        }

        _isWalking = false;
        return 0f;
    }

    public void Execute()
    {
        _isWalking = true;
        Debug.Log("[" + this.gameObject.name + "] is walking...");
    }
    

    private void Walking()
    {
        if (_isWalking)
        {
            if (_target != null && Vector3.Distance(ParentObject.transform.position, _target.transform.position) > 1f)
            {
                _animator.SetBool("isWalking", true);
                ParentObject.transform.LookAt(_target.transform);
                Vector3 newPosition = Vector3.Lerp(ParentObject.transform.position, _target.transform.position, Speed * Time.deltaTime);
                ParentObject.transform.position = newPosition;
            }
        }

    }
}
