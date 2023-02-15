using Components.Interfaces;
using UnityEngine;

namespace Components
{
    public class ShootAbility: MonoBehaviour, IAbility
    {
        public GameObject _cannon;
        public GameObject _bullet;
        
        public float _timeOut = 3f;

        private float _currentTime;

        public void Execute()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _timeOut)
            {
                _currentTime = 0f;
                
                if (_bullet != null && _cannon != null)
                {
                    GameObject newBullet = Instantiate(_bullet, _cannon.transform.position, _cannon.transform.rotation);
                    Rigidbody newBulletRigidbody = newBullet.GetComponent<Rigidbody>();
                    SphereCollider newBulletCollider = newBullet.GetComponent<SphereCollider>();

                    newBulletCollider.isTrigger = false;
                    newBulletRigidbody.isKinematic = false;
                    
                    newBulletRigidbody.AddForce(Vector3.right, ForceMode.Impulse);
                    
                    Debug.Log("Shoot");
                }
                else
                    Debug.LogError("[SHOOT ABILITY] No bullet or cannon prefab");
            }
        }
        
    }
}