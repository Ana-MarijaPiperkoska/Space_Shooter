using Unity.Entities;
using Unity.Mathematics;

public struct EnemyMoveInput : IComponentData
{
    public float2 Value;
}

public struct EnemyMoveSpeed : IComponentData
{
    public float Value;
}
