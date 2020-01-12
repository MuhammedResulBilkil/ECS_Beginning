using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MoverSystem2 : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent2 moveSpeedComponent2) =>
        {
            translation.Value.y += moveSpeedComponent2.moveSpeed * Time.DeltaTime;

            if(translation.Value.y > 5f)
                moveSpeedComponent2.moveSpeed = -math.abs(moveSpeedComponent2.moveSpeed);

            if (translation.Value.y < -5f)
                moveSpeedComponent2.moveSpeed = +math.abs(moveSpeedComponent2.moveSpeed);
        });
    }
}
