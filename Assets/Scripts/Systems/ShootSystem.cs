using Components;
using Components.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class ShootSystem: ComponentSystem
    {
        private float _currentTime;

        private bool shooted;

        protected override void OnUpdate()
        {
            _currentTime += Time.DeltaTime;

            if (_currentTime <= 3f)
            {
                if (!shooted)
                {
                    Entities.WithAll<TargetData>().ForEach((Entity entity, Transform transform) => 
                    {
                        Entities.WithAll<FirstCannon>().ForEach((Entity entity, ShootAbility shootAbility) =>
                        {
                            shootAbility.TargetGameObject = transform.gameObject;
                            shootAbility.Execute();
                            shooted = true;
                        });
                    });
                }
            }
            else
            {
                _currentTime = 0f;
                shooted = false;
            }
        }
    }
}