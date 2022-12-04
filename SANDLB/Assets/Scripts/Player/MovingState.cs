using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : PlayerState
{
    protected int positionIndex = 0;
    public override void Move(ref float startTime, ref float travelLength,
        List<Vector3> positions, GameObject player, float speed)
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / travelLength;

        player.transform.position = Vector3.Lerp(positions[positionIndex], positions[positionIndex + 1], fractionOfJourney);

        if(player.transform.position == positions[positions.Count - 1])
        {
            player.GetComponent<PlayerScript>().StartCoroutine(player.GetComponent<PlayerScript>().ChangeStateDelayed(new IdleState(), 1f));
        }
        if(positionIndex + 2 == positions.Count)
        {
            return;
        }
        if(player.transform.position == positions[positionIndex + 1])
        {
            positionIndex++;
            startTime = Time.time;
            travelLength = Vector3.Distance(positions[positionIndex], positions[positionIndex + 1]);
        }
    }
    public override void StartMoving(ref float startTime, ref float travelLength,
        List<Vector3> positions, GameObject player)
    {
        return;
    }
    public override string GetPlayerState()
    {
        return "moving";
    }
}
