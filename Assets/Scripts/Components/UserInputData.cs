using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    [HideInInspector] public float _speed = 0.01f;

    public float _rushPower;
    
    public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
    {
        entityManager.AddComponentData<InputData>(entity, new InputData());
        entityManager.AddComponentData<MoveData>(entity, new MoveData { Speed = _speed });
        entityManager.AddComponentData<RushData>(entity, new RushData { RushPower = _rushPower });
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
    public float RushActive;
    public float RushPower;
}