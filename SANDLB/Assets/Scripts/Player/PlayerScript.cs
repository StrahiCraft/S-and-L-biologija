using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed;

    List<Vector3> positions;

    float startTime = 0;
    float travelLength = 0;

    PlayerState currentState = new IdleState();

    void Update()
    {
        currentState.Move(ref startTime, ref travelLength, positions, gameObject, speed); 
    }

    public void ChangeState(PlayerState newState)
    {
        currentState = newState;
    }

    public void StartPlayerMotion(List<Vector3> newEndPositions)
    {
        positions = newEndPositions;
        currentState.StartMoving(ref startTime, ref travelLength, positions, gameObject);
    }
    public string GetPlayerState()
    {
        return currentState.GetPlayerState();
    }
}
