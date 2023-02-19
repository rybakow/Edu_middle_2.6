using System.Collections;
using System.Collections.Generic;
using Components.Interfaces;
using UnityEngine;

public class DamageAbility : CollisionAbility, ICollisionAbility
{
    public int Damage = 50;

    public void Execute()
    {
        foreach (var target in Collisions)
        {
            var go = target?.gameObject;
            Debug.Log(go?.name);
        }
    }

}
