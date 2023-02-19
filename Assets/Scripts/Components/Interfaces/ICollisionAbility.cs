using System.Collections.Generic;
using UnityEngine;

namespace Components.Interfaces
{
    public interface ICollisionAbility: IAbility
    {
        List<Collider> Collisions { get; set; }
    }
}