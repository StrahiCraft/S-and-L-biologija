using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public abstract void UpdatePath(ref Vector3 startPos, ref Vector3 endPos, Vector3 newStartPos, Vector3 newEndPos);
    public abstract void StartMoving(ref float startTime, ref float travelLength,
        Vector3 startPos, Vector3 endPos, GameObject player);
    public abstract void Move(float startTime, float travelLength,
        Vector3 startPos, Vector3 endPos, GameObject player, float speed);
    public abstract int MoveToNextField();//za sad da kazemo da je privremeno moglo bi bloje da se implementira kad imamo stanja od polja
}
