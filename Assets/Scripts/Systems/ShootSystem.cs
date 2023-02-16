using Components;
using Unity.Entities;

namespace Systems
{
    public class ShootSystem: ComponentSystem
    {
        private EntityQuery _entityQuery;

        protected override void OnCreate()
        {
            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<ShootAbility>());
        }
        
        protected override void OnUpdate()
        {
            Entities.With(_entityQuery).ForEach((
                Entity entity, ShootAbility shootAbility) =>
            {
                shootAbility.Execute();
            });
        }
    }
}