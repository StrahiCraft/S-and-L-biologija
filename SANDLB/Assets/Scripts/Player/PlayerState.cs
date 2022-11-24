using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public abstract void StartMoving(ref float startTime, ref float travelLength,
        List<Vector3> positions, GameObject player);
    public abstract void Move(ref float startTime, ref float travelLength,
        List<Vector3> positions, GameObject player, float speed);
    public abstract string GetPlayerState();
}
