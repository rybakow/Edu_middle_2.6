using System.Collections.Generic;
using Components.Interfaces;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Components
{
    public class BehaviourManager : MonoBehaviour, IConvertGameObjectToEntity
    {

        public List<MonoBehaviour> Behaviours;
        public IBehaviour activeBehaviour;

        public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
        {
            entityManager.AddComponent<AIAgent>(entity);
        }

    }
    
    public struct AIAgent : IComponentData
    {
    }
}
