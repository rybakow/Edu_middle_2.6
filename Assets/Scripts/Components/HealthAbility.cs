using Components.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace Components
{
    public class HealthAbility : CollisionAbility, ICollisionAbility, IConvertGameObjectToEntity
    {
        public int Health = 100;

        public void Execute()
        {

            foreach (var target in Collisions)
            {
                var targetHealth = target?.gameObject?.GetComponent<CharacterHealth>();

                if (targetHealth != null)
                {
                    targetHealth.Health += Health;
                    Debug.Log(this.gameObject.name + " [HEALTH] for " + target.gameObject.name + " and health after collision = " + targetHealth.Health);

                    this.GetComponent<Animator>().SetTrigger("Destroy");

                    Destroy(this.GetComponent<HealthAbility>());
                }
            }
        }
    }
}
