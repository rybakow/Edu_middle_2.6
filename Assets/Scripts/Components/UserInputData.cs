using System;
using System.Collections;
using System.Collections.Generic;
using Components.Interfaces;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    [HideInInspector] public float _moveSpeed;
    [HideInInspector] public bool _rushAbility;
    
    public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
    {
        _moveSpeed = 0.01f;
        _rushAbility = true;
        
        entityManager.AddComponentData<InputData>(entity, new InputData());
        entityManager.AddComponentData<MoveData>(entity, new MoveData { Speed = _moveSpeed });
        entityManager.AddComponentData<RushData>(entity, new RushData { RushAbility = _rushAbility});
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
    public float RushValue;
    public bool RushAbility;
}
