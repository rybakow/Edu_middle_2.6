using System;
using System.Collections.Generic;
using System.Linq;
using Components.Interfaces;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Systems
{
    public class CollisionSystem: ComponentSystem
    {
        private EntityQuery _entityQuery;
        
        protected override void OnCreate()
        {
            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<ColliderData>(), ComponentType.ReadOnly<Transform>());
        }

        protected override void OnUpdate()
        {
            Entities.With(_entityQuery).ForEach((Entity entity, CollisionAbility collisionAbility, ref ColliderData colliderData) =>
            {
                var gameObject = collisionAbility?.gameObject;
                float3 position = gameObject.transform.position;
                Quaternion rotation = gameObject.transform.rotation;

                var _results = new Collider[50];
                
                collisionAbility.Collisions?.Clear();

                int size = 0;

                switch (colliderData.ColliderType)
                {
                    case ColliderType.Capsule:
                        var center = ((colliderData.CapsuleStart + position) + (colliderData.CapsuleEnd + position)) / 2f;
                        var point1 = colliderData.CapsuleStart + position;
                        var point2 = colliderData.CapsuleEnd + position;
                        point1 = (float3)(rotation * (point1 - center)) + center;
                        point2 = (float3)(rotation * (point2 - center)) + center;
                        size = Physics.OverlapCapsuleNonAlloc(point1, point2, colliderData.CapsuleRadius, _results);
                        break;
                    
                    case ColliderType.Box:
                        size = Physics.OverlapBoxNonAlloc(colliderData.BoxCenter + position, colliderData.BoxHalfExtents, _results, colliderData.BoxOrientation * rotation);
                        break;
                    
                    case ColliderType.Sphere:
                        size = Physics.OverlapSphereNonAlloc(colliderData.SphereCenter + position, colliderData.SphereRadius, _results);
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (size > 0)
                {
                    foreach (var result in _results)
                    {
                        collisionAbility?.Collisions?.Add(result);
                    }

                    collisionAbility.Execute();
                }
            });
        }
    }
}