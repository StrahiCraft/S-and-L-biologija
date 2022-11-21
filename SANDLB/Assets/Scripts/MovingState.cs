using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : PlayerState
{
    public override void UpdatePath(ref Vector3 startPos, ref Vector3 endPos, Vector3 newStartPos, Vector3 newEndPos)
    {
        return;
    }
    public override void Move(float startTime, float travelLength,
        Vector3 startPos, Vector3 endPos, GameObject player, float speed)
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / travelLength;

        player.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

        if(player.transform.position == endPos)
        {
            player.GetComponent<PlayerScript>().ChangeState(new IdleState());
        }
    }
    public override void StartMoving(ref float startTime, ref float travelLength,
        Vector3 startPos, Vector3 endPos, GameObject player)
    {
        return;
    }
    public override int MoveToNextField()
    {
        return 0;
    }
}
