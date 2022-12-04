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

    public IEnumerator ChangeStateDelayed(PlayerState newState, float delay)
    {
        yield return new WaitForSeconds(delay);
        currentState = newState;
    }

    public void StartPlayerMotion(List<Vector3> newEndPositions)
    {
        if(newEndPositions.Count == 0)
        {
            return;
        }
        positions = newEndPositions;
        currentState.StartMoving(ref startTime, ref travelLength, positions, gameObject);
    }
    public string GetPlayerState()
    {
        return currentState.GetPlayerState();
    }

    IEnumerator GracePeriodBeforeIdleState()
    {
        yield return new WaitForSeconds(1f);
        ChangeState(new IdleState());
        StopCoroutine(GracePeriodBeforeIdleState());
    }
}
