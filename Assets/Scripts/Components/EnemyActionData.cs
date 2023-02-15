using Components.Interfaces;
using Unity.Entities;
using UnityEngine;


public class EnemyActionData: MonoBehaviour, IConvertGameObjectToEntity
{ 
    public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem) 
    { 
        entityManager.AddComponentData<EnemyShootData>(entity, new EnemyShootData());
    }
}
public struct EnemyShootData : IComponentData
{
    
}