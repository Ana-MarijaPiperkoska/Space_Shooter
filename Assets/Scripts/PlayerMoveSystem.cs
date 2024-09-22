using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;

[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct PlayerMoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        
        var jobHandle = new PlayerMoveJob
        {
            DeltaTime = deltaTime
        }.Schedule(state.Dependency);  

       
        state.Dependency = jobHandle;
    }
}

public partial struct PlayerMoveJob : IJobEntity
{
    public float DeltaTime;

    [BurstCompile]
    private void Execute(ref LocalTransform transform, in PlayerMoveInput input, PlayerMoveSpeed speed)
    {
        transform.Position.xy += input.Value * speed.Value * DeltaTime;
    }
}
