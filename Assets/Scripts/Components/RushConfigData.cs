using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class RushConfigData : MonoBehaviour, IConvertGameObjectToEntity
{
    [HideInInspector] public float _rushSpeed;
    [HideInInspector] public float _rushTime;

    public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
    {
        _rushSpeed = 0.01f;
        _rushTime = 0.5f;

        entityManager.AddComponentData<RushConfig>(entity, new RushConfig
        {
            RushSpeed = _rushSpeed, RushTime = _rushTime
        });
    }
}

public struct RushConfig : IComponentData
{
    public float RushSpeed;
    public float RushTime;
}
