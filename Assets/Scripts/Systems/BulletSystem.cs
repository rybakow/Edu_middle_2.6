using Components;
using Components.Interfaces;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public class BulletSystem: ComponentSystem
    {
        private float _currentTime;

        private bool shooted;

        protected override void OnUpdate()
        {
            if (!Input.GetButtonDown("Fire1"))
                return;

            Entities.ForEach((Entity entity, BulletPrefabComponent bulletPrefab) => {
                var shooter = EntityManager.GetComponentObject<CannonComponent>(entity);
                if (shooter == null)
                    Debug.LogError("BulletPrefabComponent is missing Shooter component.");
                else
                {
                    Entity bullet = EntityManager.Instantiate(bulletPrefab.prefab);
                    EntityManager.SetComponentData(bullet, new Translation { Value = shooter.gunHole.position });
                    EntityManager.SetComponentData(bullet, new Rotation { Value = shooter.gunHole.rotation });
                    EntityManager.AddComponentData(bullet, new BulletComponent { speed = shooter.gunHole.forward * bulletPrefab.speed });
                }
            });
        }
    }
}