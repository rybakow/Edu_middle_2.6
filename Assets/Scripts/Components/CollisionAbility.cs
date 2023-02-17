using System.Collections;
using System.Collections.Generic;
using Components.Interfaces;
using DefaultNamespace;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CollisionAbility : MonoBehaviour, IAbility, IConvertGameObjectToEntity
{

    public Collider _collider;

    public void Execute()
    {
        Debug.Log("Hi!");
    }
    
    public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
    {
        float3 position = this.gameObject.transform.position;

        switch (_collider)
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
        }

        _collider.enabled = false;
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
    public bool initialTakeOff;

}

public enum ColliderType
{
    Capsule = 0,
    Box = 1
}