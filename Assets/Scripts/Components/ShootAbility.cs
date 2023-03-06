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

        private EntityManager entityManager;
        private Entity _cannonEntity;
        private BlobAssetStore _blobAssetStore;

        private void Awake()
        {
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            _blobAssetStore = new BlobAssetStore();
            GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, _blobAssetStore);
            _cannonEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(Cannon, settings);
        }

        public void Execute()
        {
            var targetCoordinates = TargetGameObject.transform.position;
            
            Vector3 attackVector3 = targetCoordinates - Cannon.transform.position;
            
            //var newBullet = Instantiate(Cannon, Cannon.transform.position, Cannon.transform.rotation);

            Entity newEntity = entityManager.Instantiate(_cannonEntity);


            //newBullet.transform.LookAt(targetCoordinates);

            //newBullet.GetComponent<SphereCollider>().isTrigger = false;

            //var rigidbody = newBullet.GetComponent<Rigidbody>();
            //rigidbody.isKinematic = false;
            //rigidbody.AddForce(attackVector3 * 500f);
            
            //Destroy(newBullet.GetComponent<ShootAbility>());
        }
        
        
    }
}
