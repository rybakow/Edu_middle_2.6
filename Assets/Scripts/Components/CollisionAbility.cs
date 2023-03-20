using System.Collections;
using System.Collections.Generic;
using Components.Interfaces;
using DefaultNamespace;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class CollisionAbility : MonoBehaviour, IConvertGameObjectToEntity, ICollisionAbility
{

    public Collider Collider;

    public List<Collider> Collisions { get; set; }
    
    
    public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
    {
        float3 position = this.gameObject.transform.position;

        switch (Collider)
        {
            case CapsuleCollider capsule:
                capsule.ToWorldSpaceCapsule(out var capsuleStart, out var capsuleEnd, out var capsuleRadius);
                entityManager.AddComponentData(entity, new ColliderData
                {
                    ColliderType = ColliderType.Capsule,
                    CapsuleStart = capsuleStart - position,
                    CapsuleEnd = capsuleEnd - position,
                    CapsuleRadius = capsuleRadius,
                    initialTakeOff = true
                    
                });
                break;

            case BoxCollider box:
                box.ToWorldSpaceBox(out var boxCenter, out var boxHalfExtents, out var boxOrientation);
                entityManager.AddComponentData(entity, new ColliderData
                {
                    ColliderType = ColliderType.Box,
                    BoxCenter = boxCenter - position,
                    BoxHalfExtents = boxHalfExtents,
                    BoxOrientation = boxOrientation,
                    initialTakeOff = true
                });
                break;
            
            case SphereCollider sphere:
                sphere.ToWorldSpaceSphere(out var sphereCenter, out var sphereRadius);
                entityManager.AddComponentData(entity, new ColliderData
                {
                    ColliderType = ColliderType.Sphere,
                    SphereCenter = sphereCenter - position,
                    SphereRadius = sphereRadius,
                    initialTakeOff = true
                });
                break;
        }
        
    }
    
}

public struct ColliderData: IComponentData
{
    public ColliderType ColliderType;
    public float3 CapsuleStart;
    public float3 CapsuleEnd;
    public float CapsuleRadius;
    public float3 BoxCenter;
    public float3 BoxHalfExtents;
    public quaternion BoxOrientation;
    public float3 SphereCenter;
    public float SphereRadius;
    public bool initialTakeOff;

}

public enum ColliderType
{
    Capsule = 0,
    Box = 1,
    Sphere = 2
}