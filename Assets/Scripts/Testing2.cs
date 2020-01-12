using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class Testing2 : MonoBehaviour
{
    public int entityNumber;

    [SerializeField]
    private Mesh mesh;
    [SerializeField]
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(LevelComponent2),
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(MoveSpeedComponent2)
            );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(entityNumber, Allocator.Temp);

        entityManager.CreateEntity(entityArchetype, entityArray);

        foreach (Entity entity in entityArray)
        {
            entityManager.SetComponentData(entity, new LevelComponent2 { level = UnityEngine.Random.Range(10f, 20f) });
            entityManager.SetComponentData(entity, new MoveSpeedComponent2 { moveSpeed = UnityEngine.Random.Range(1f, 2f) });
            entityManager.SetComponentData(entity, new Translation { Value = new float3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-5f, 5f), 0f) });
            entityManager.SetSharedComponentData(entity, new RenderMesh { mesh = mesh, material = material });
        }

        entityArray.Dispose();

    }
}
