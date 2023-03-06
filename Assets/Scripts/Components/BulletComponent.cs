using DefaultNamespace;
using Unity.Entities;
using Unity.Mathematics;


public class BulletComponent: IComponentData
{
    public float3 speed;
    public bool destroyed;
}
