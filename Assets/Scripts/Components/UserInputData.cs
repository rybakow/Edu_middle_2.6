using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    [HideInInspector] public float speed;
    
    public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
    {
        entityManager.AddComponentData<InputData>(entity, new InputData());
        entityManager.AddComponentData<MoveData>(entity, new MoveData { Speed = speed });
        entityManager.AddComponentData<RushData>(entity, new RushData());
    }
}

public struct InputData : IComponentData
{
    public float2 Move;
}

public struct MoveData : IComponentData
{
    public float Speed;
}

public struct RushData : IComponentData
{
    public float Rush;
}