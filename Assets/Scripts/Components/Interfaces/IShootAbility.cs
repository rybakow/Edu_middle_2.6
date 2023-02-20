using UnityEngine;

namespace Components.Interfaces
{
    public interface IShootAbility: IAbility
    {
        GameObject TargetGameObject { get; set; }
    }
}