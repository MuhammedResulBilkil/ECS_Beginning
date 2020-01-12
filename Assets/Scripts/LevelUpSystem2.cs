using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class LevelUpSystem2 : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref LevelComponent2 levelComponent) =>
        {
            levelComponent.level += 1f * Time.DeltaTime;
           // Debug.Log(levelComponent.level);
        });
    }
}
