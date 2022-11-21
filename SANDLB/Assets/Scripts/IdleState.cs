using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public override void UpdatePath(ref Vector3 startPos, ref Vector3 endPos, Vector3 newStartPos, Vector3 newEndPos)
    {
        startPos = newStartPos;
        endPos = newEndPos;
    }
    public override void Move(float startTime, float travelLength,
        Vector3 startPos, Vector3 endPos, GameObject player, float speed)
    {
        return;
    }
    public override void StartMoving(ref float startTime, ref float travelLength,
        Vector3 startPos, Vector3 endPos, GameObject player)
    {
        startTime = Time.time;
        travelLength = Vector3.Distance(startPos, endPos);
        player.GetComponent<PlayerScript>().ChangeState(new MovingState());
    }
    public override int MoveToNextField()
    {
        return 1;
    }
}
