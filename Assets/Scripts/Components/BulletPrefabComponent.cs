using DefaultNamespace;
using Unity.Entities;
using Unity.Mathematics;


public class BulletPrefabComponent: IComponentData
{
    public Entity prefab;
    public float speed;
}
