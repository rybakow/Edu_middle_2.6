using Components.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace Components
{
    public class DamageAbility : CollisionAbility, ICollisionAbility, IConvertGameObjectToEntity
    {
        public int Damage = 50;

        public void Execute()
        {
            foreach (var target in Collisions)
            {
               var targetHealth = target?.gameObject?.GetComponent<CharacterHealth>();

               if (targetHealth != null)
               {
                   targetHealth.Health -= Damage;
                   Debug.Log("HIT for [" + target.gameObject.name + "] and health after collision = " + targetHealth.Health);
                }
            }
        }
    }
}
