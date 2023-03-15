using Components;
using Components.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class ShootSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {

            Entities.WithAll<TargetData>().ForEach((Entity entity, Transform transform) =>
            {
                Entities.WithAll<ShootAbility>().ForEach((Entity entity, ShootAbility shootAbility) =>
                 {
                   shootAbility.TargetGameObject = transform.gameObject;
                   shootAbility.Execute();

               });
            });
        }

    }
}