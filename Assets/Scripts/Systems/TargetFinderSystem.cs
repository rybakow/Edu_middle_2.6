using Components;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class TargetFinderSystem: ComponentSystem
    {
        private EntityQuery _entityQuery;
        private EntityQuery _entiryWeaponQuery;
        
        protected override void OnCreate()
        {
            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<TargetData>());
        }
        
        protected override void OnUpdate()
        {
            Entities.With(_entityQuery).ForEach((Entity entity, Transform transform, ref TargetCoordinates targetCoordinates) =>
            {
                targetCoordinates.coordinates = transform.position;
            });
            
        }

    }
}