using System.Security.Cryptography;
using Components.Interfaces;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Components
{
    public class ShootAbility: MonoBehaviour, IAbility
    {
        public GameObject _cannon;
        
        public void Execute(Vector3 targetCoordinates)
        {
            Vector3 attackVector3 = targetCoordinates - _cannon.transform.position;
            
            var newBullet = Instantiate(this.gameObject, _cannon.transform.position, _cannon.transform.rotation);
            
            newBullet.transform.LookAt(targetCoordinates);

            newBullet.GetComponent<SphereCollider>().isTrigger = false;

            var rigidbody = newBullet.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.AddForce(attackVector3 * 500f);
            
            Destroy(newBullet.GetComponent<ShootAbility>());
        }
    }
}
