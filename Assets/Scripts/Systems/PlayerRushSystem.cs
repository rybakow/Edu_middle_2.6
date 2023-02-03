using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class PlayerRushSystem : ComponentSystem
    {
        private EntityQuery _entityQuery;

        protected override void OnCreate()
        {
            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<RushData>());
        }


        protected override void OnUpdate()
        {
            Entities.With(_entityQuery).ForEach((
                Entity entity, Transform transform, ref RushData rushData) =>
            {
                Debug.Log(rushData.Rush);
            });
        }
    }
}