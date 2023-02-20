using Components.Interfaces;
using UnityEngine;

namespace Components
{
    public class ShootAbility: MonoBehaviour, IShootAbility
    {
        public GameObject _cannon;

        public GameObject _cannonCore;
        
        public GameObject TargetGameObject { get; set; }
        
        public void Execute()
        {
            var targetCoordinates = TargetGameObject.transform.position;
            
            Vector3 attackVector3 = targetCoordinates - _cannon.transform.position;
            
            var newBullet = Instantiate(_cannonCore, _cannon.transform.position, _cannon.transform.rotation);
            
            newBullet.transform.LookAt(targetCoordinates);

            newBullet.GetComponent<SphereCollider>().isTrigger = false;

            var rigidbody = newBullet.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.AddForce(attackVector3 * 500f);
            
            Destroy(newBullet.GetComponent<ShootAbility>());
        }
        
        
    }
}
