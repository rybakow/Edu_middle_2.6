using Components;
using Components.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class AIExecuteSystem : ComponentSystem
    {
        private EntityQuery _entityQuery;
        
        
        protected override void OnCreate()
        {
            _entityQuery = GetEntityQuery(ComponentType.ReadOnly<AIAgent>());
        }
        
        
        protected override void OnUpdate()
        {

            Entities.With(_entityQuery).ForEach((Entity entity, BehaviourManager behaviourManager) =>
            {
                behaviourManager.activeBehaviour?.Execute();
            });
        }

    }
}