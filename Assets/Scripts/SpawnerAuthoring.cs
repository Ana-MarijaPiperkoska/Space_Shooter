using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class SpawnerAuthoring : MonoBehaviour
{

    public GameObject Prefab;
    public float SpawnRate;

    class SpawnBaker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            float3 spawnerPosition = authoring.transform.position;
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new Spawner
            {
                Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                SpawnPosition = new float2(spawnerPosition.x, spawnerPosition.y),
                NextSpawnTime = 0,
                SpawnRate = authoring.SpawnRate
            });
        }
    }

}