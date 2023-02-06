using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class PlayerMoveSystem : ComponentSystem
    {
        private EntityQuery _entityQuery;

        protected override void OnCreate()
        {
            _entityQuery = GetEntityQuery(
                ComponentType.ReadOnly<InputData>(), 
                ComponentType.ReadOnly<MoveData>(),
                ComponentType.ReadOnly<Transform>());
        }
        
        protected override void OnUpdate()
        {
            Entities.With(_entityQuery).ForEach((
                Entity entity, Transform transform, ref InputData inputData, ref MoveData moveData) =>
            {
                var position = transform.position;
                position += new Vector3(inputData.Move.x * moveData.Speed, 0, inputData.Move.y * moveData.Speed);
                transform.LookAt(position);
                transform.position = position;
            });
        }
    }
}