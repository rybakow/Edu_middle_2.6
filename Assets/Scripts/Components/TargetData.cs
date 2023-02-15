using Unity.Entities;
using UnityEngine;

namespace Components
{
    public class TargetData : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
        {
            entityManager.AddComponentData<TargetCoordinates>(entity, new TargetCoordinates());
        }
    }
    
    public struct TargetCoordinates : IComponentData
    {
        public Transform transform;
    }
}
