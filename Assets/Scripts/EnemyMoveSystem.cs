using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;

[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct EnemyMoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        var jobHandle = new EnemyMoveJob
        {
            DeltaTime = deltaTime
        }.Schedule(state.Dependency);

        state.Dependency = jobHandle;
    }
}

public partial struct EnemyMoveJob : IJobEntity
{
    public float DeltaTime;

    [BurstCompile]
    private void Execute(ref LocalTransform transform, in EnemyMoveInput input, in EnemyMoveSpeed speed)
    {

        transform.Position.xy += input.Value * speed.Value * DeltaTime;
    }
}
