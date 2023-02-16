using System.Collections;
using System.Collections.Generic;
using Components.Interfaces;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollisionAbility : MonoBehaviour, IAbility, IConvertGameObjectToEntity
{

    public Collider _collider;
    
    public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
    {
        float3 position = this.gameObject.transform.position;

        switch (_collider)
        {
            case CapsuleCollider capsule:
                // Here 
                break;
        }
    }
   
}

public struct ColliderData: IComponentData
{
    public Tile.ColliderType ColliderType;
    public float3 CapsuleStart;
    public float3 CapsuleEnd;
    public float3 CapsuleRadius;
    public bool initialTakeOff;

}