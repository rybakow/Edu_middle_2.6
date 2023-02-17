using System.Collections;
using System.Collections.Generic;
using Components.Interfaces;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CollisionAbility : MonoBehaviour, IAbility, IConvertGameObjectToEntity
{

    public Collider _collider;
    
    public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
    {
        float3 position = this.gameObject.transform.position;

        switch (_collider)
        {
            case CapsuleCollider capsule:
                
                entityManager.AddComponentData<ColliderData>(entity, new ColliderData
                {
                    ColliderType = ColliderType.Capsule,
                    CapsuleStart = capsuleStart - position,
                    CapsuleEnd = capsuleEnd - position,
                    CapsuleRadius = capsuleRadius,
                    initialTakeOff = true
                    
                });
                break;
            case BoxCollider box:
                //
                break;
        }
    }
   
}

public struct ColliderData: IComponentData
{
    public ColliderType ColliderType;
    public float3 CapsuleStart;
    public float3 CapsuleEnd;
    public float3 CapsuleRadius;
    public float3 BoxCenter;
    public float3 BoxHalfExtents;
    public quaternion BoxOrientation;
    public bool initialTakeOff;

}

public enum ColliderType
{
    Capsule = 0,
    Box = 1
}