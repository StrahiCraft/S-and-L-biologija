using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public override void Move(ref float startTime, ref float travelLength,
        List<Vector3> positions, GameObject player, float speed)
    {
        return;
    }
    public override void StartMoving(ref float startTime, ref float travelLength,
        List<Vector3> positions, GameObject player)
    {
        startTime = Time.time;
        travelLength = Vector3.Distance(positions[0], positions[1]);
        player.GetComponent<PlayerScript>().ChangeState(new MovingState());
    }
    public override string GetPlayerState()
    {
        return "idle";
    }
}
