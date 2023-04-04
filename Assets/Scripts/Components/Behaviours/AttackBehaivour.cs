using System.Collections.Generic;
using Components.Interfaces;
using UnityEngine;

public class AttackBehaivour : MonoBehaviour, IBehaviour
{
    public GameObject ParentObject;
    
    private Animator _animator;
    
    private GameObject _target;
    
    private void Start()
    {
        _animator = this.GetComponent<Animator>();
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
                
                if (Vector3.Distance(ParentObject.transform.position, _target.transform.position) <= 1.4f)
                    return 3f;
            }
                
        }
        
        return 0f;
    }

    public void Execute()
    {
        Attack();
        Debug.Log("[" + this.gameObject.name + "] is attacking...");
    }


    public void Attack()
    {
        ParentObject.transform.LookAt(_target.transform);
        _animator.SetTrigger("Attack");
    }
}
