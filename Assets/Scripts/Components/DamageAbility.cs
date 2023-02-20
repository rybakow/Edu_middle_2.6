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
                   Debug.Log(target.gameObject.name);
                   targetHealth.Health -= Damage;
               }
            }
        }
    }
}
