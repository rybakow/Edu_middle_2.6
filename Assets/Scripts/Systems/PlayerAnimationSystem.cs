using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class PlayerAnimationSystem : ComponentSystem
    {
        private EntityQuery _entityQuery;

        private Vector3 prevPosition;

        protected override void OnCreate()
        {
            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<Animator>(), ComponentType.ReadOnly<CharacterHealth>());
        }


        protected override void OnUpdate()
        {
            
            Entities.With(_entityQuery).ForEach((Entity entity, Transform transform, Animator animator) =>
            {
                if (prevPosition == null)
                    prevPosition = transform.position;

                Vector3 velocity;

                if (transform.position != prevPosition)
                    velocity = (transform.position - prevPosition) / Time.DeltaTime;
                else
                    velocity = Vector3.zero;
                
                animator.SetFloat("Speed", velocity.magnitude);

                if (velocity.magnitude > 0f)
                {
                    animator.SetBool("Walk", true);
                }
                else
                {
                    animator.SetBool("Walk", false);
                }
                
                prevPosition = transform.position;
            });
        }
    }
}