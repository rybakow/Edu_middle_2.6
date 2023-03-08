using Components.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace Components
{
    public class ShootAbility: MonoBehaviour, IShootAbility
    {
        public GameObject Cannon;

        public GameObject CannonCore;
        
        public GameObject TargetGameObject { get; set; }

        private EntityManager _entityManager;

        private void Awake()
        {
            _entityManager = new EntityManager();
        }

        public void Execute()
        {
            var targetCoordinates = TargetGameObject.transform.position;
            
            Vector3 attackVector3 = targetCoordinates - Cannon.transform.position;
            
            var newBullet = Instantiate(CannonCore, Cannon.transform.position, Cannon.transform.rotation);
            
            newBullet.transform.LookAt(targetCoordinates);

            newBullet.GetComponent<SphereCollider>().isTrigger = false;
    
            var rigidbody = newBullet.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.AddForce(attackVector3 * 500f);

            //newBullet.AddComponent<ConvertToEntity>().ConversionMode = ConvertToEntity.Mode.ConvertAndInjectGameObject;


            Destroy(newBullet.GetComponent<FirstCannon>());
        }
        
        
    }
}
