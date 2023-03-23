using System;
using Components.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace Components
{
    public class ShootAbility : MonoBehaviour, IShootAbility
    {
        public GameObject Cannon;

        public GameObject CannonCore;

        public GameObject TargetGameObject { get; set; }

        private float _shootTime = float.MinValue;

        private PlayerStat _playerStat;

        private void Start()
        {
            _playerStat = new PlayerStat();
        }


        public void Execute()
        {
            if (Time.time < _shootTime + 3f) return;

            _shootTime = Time.time;


            var targetCoordinates = TargetGameObject.transform.position;

            Vector3 attackVector3 = targetCoordinates - Cannon.transform.position;

            var newBullet = Instantiate(CannonCore, Cannon.transform.position, Cannon.transform.rotation);

            newBullet.transform.LookAt(targetCoordinates);

            newBullet.GetComponent<SphereCollider>().isTrigger = false;

            var rigidbody = newBullet.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.AddForce(attackVector3 * 500f);

            Destroy(newBullet.GetComponent<ShootAbility>());
        }


    }
}
