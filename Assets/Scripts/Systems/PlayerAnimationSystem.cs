using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class PlayerAnimationSystem : ComponentSystem
    {
        private EntityQuery _entityQuery;

        private float prevMagnitude;

        protected override void OnCreate()
        {
            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<Animator>());
        }


        protected override void OnUpdate()
        {
            Entities.With(_entityQuery).ForEach((Entity entity, ref RushData rushData) =>
            {
                if (rushData.RushValue == 1)
                {
                    
                }
                    
            });
            
            Entities.With(_entityQuery).ForEach((Entity entity, Transform transform, Animator animator) =>
            {
                float actualMagnitude = transform.position.magnitude;

                if (actualMagnitude != prevMagnitude)
                {
                    animator.SetBool("Walk", true);
                }
                else
                {
                    animator.SetBool("Walk", false);
                }

                prevMagnitude = actualMagnitude;
            });
        }
    }
}