using Components.Interfaces;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Entities;
using UnityEngine;

namespace Components
{
    public class ApplyDamage : MonoBehaviour, IAbilityTarget
    {
        public int Damage = 50;

        public List<GameObject> Targets { get; set; }

        private bool _gotten;


        public void Execute()
        {
            if (_gotten) return;

            foreach (var target in Targets)
            {
                var targetHealth = target?.gameObject?.GetComponent<CharacterHealth>();

                if (targetHealth != null)
                {
                    _gotten = true;

                    targetHealth.Health -= Damage;
                    GameManager.Health = targetHealth.Health;
                    
                    Debug.Log("[DAMAGE] for " + target.gameObject.name + " and health after collision = " + targetHealth.Health);
                }
            }

        }
    }
}
