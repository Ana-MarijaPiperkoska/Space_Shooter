using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ProjectileAuthoring : MonoBehaviour
{

    public float ProjectileSpeed;

    public class ProjectileAuthoringBaker : Baker<ProjectileAuthoring>
    {

        public override void Bake(ProjectileAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<FireProjectileTag>(entity);
            AddComponent(entity, new ProjectileSpeed { Value = authoring.ProjectileSpeed });

        }
    }

}

