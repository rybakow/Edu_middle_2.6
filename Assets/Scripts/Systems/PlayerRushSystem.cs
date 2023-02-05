using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class PlayerRushSystem : ComponentSystem
    {
        private EntityQuery _entityQuery;

        private bool _rushInProgress;
        private float _currentTime;

        protected override void OnCreate()
        {
            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<RushData>());
        }


        protected override void OnUpdate()
        {
            Entities.With(_entityQuery).ForEach((
                Entity entity, Transform transform, ref RushData rushData) =>
            {
                if (rushData.RushActive >= 1f)
                {
                    Debug.Log("Rush");
                }
            });
        }
    }
}