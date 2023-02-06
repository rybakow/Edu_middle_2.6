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
                Entity entity, Transform transform, ref RushData rushData, ref RushConfig rushConfig) =>
            {
                if (rushData.RushValue >= 1f)
                {
                    _rushInProgress = true;
                    rushData.RushAbility = false;
                }

                if (_rushInProgress)
                {
                    _currentTime += Time.DeltaTime;
                    
                    transform.Translate(Vector3.forward * _currentTime * rushConfig.RushSpeed);

                    if (_currentTime >= rushConfig.RushTime)
                    {
                        rushData.RushAbility = true;
                        _rushInProgress = false;
                        _currentTime = 0f;
                    }
                }
            });
        }
    }
}