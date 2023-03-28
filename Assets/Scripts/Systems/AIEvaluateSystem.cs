using Components;
using Components.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class AIEvaluateSystem : ComponentSystem
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
                IBehaviour bestBehaviour;
                float hightScore = float.MinValue;

                behaviourManager.activeBehaviour = null;
                
                foreach (var behaviour in behaviourManager.Behaviours)
                {
                    if (behaviour is IBehaviour ai)
                    {
                        var currentScore = ai.Evaluate();

                        if (currentScore > hightScore)
                        {
                            hightScore = currentScore;
                            behaviourManager.activeBehaviour = ai;
                        }
                    }
                    
                }
            });
        }

    }
}