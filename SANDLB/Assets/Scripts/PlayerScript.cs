using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed;

    Vector3 startPosition;
    Vector3 endPostition;

    float startTime = 0;
    float travelLength = 0;

    PlayerState currentState = new IdleState();

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        currentState.Move(startTime, travelLength, startPosition, endPostition, gameObject, speed);
    }

    public void ChangeState(PlayerState newState)
    {
        currentState = newState;
    }

    public void StartPlayerMotion(Vector3 newEndPos)
    {
        currentState.UpdatePath(ref startPosition, ref endPostition, transform.position, newEndPos);
        currentState.StartMoving(ref startTime, ref travelLength, startPosition, endPostition, gameObject);
    }
    public int MoveToNextField()
    {
        return currentState.MoveToNextField();
    }
}
