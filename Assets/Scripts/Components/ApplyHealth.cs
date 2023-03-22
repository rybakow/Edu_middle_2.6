using Components.Interfaces;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Components
{
    public class ApplyHealth : MonoBehaviour, IAbilityTarget
    {
        public int Health = 100;

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

                    targetHealth.Health += Health;
                    Debug.Log("[HEALTH] for " + target.gameObject.name + " and health after collision = " + targetHealth.Health);

                    this.GetComponent<Animator>().SetTrigger("Destroy");
                }
            }

        }
    }
}
