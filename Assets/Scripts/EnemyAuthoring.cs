using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class EnemyAuthoring : MonoBehaviour
{
    public float speed = 1f;
    public float2 moveInput = new float2(1, 0);

    class Baker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);


            AddComponent(entity, new EnemyMoveInput { Value = authoring.moveInput });
            AddComponent(entity, new EnemyMoveSpeed { Value = authoring.speed });


           
        }
    }
}


