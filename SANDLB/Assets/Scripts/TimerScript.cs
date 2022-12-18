using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] GameObject timerFluid;
    Vector3 defaultTimerFluidPosition = new Vector3();
    Vector3 endTimerFluidPosition = new Vector3();

    [SerializeField] float speed;
    float journeyLength;
    float startTime;
    void Awake()
    {
        defaultTimerFluidPosition = timerFluid.transform.position;
        endTimerFluidPosition = defaultTimerFluidPosition;
    }

    void Update()
    {
        MoveTimerFluid();
    }

    public void StartTimer()
    {
        timerFluid.transform.position = defaultTimerFluidPosition;
        endTimerFluidPosition = defaultTimerFluidPosition;
        endTimerFluidPosition.y -= 10.7f;
        startTime = Time.time;
        journeyLength = Vector3.Distance(defaultTimerFluidPosition, endTimerFluidPosition);
    }

    void MoveTimerFluid()
    {
        if(endTimerFluidPosition == timerFluid.transform.position)
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>().Play("Pogresno");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().ChangeGameState(new IdleGameState());
            return;
        }
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / journeyLength;
        timerFluid.transform.position = Vector3.Lerp(defaultTimerFluidPosition, endTimerFluidPosition, fractionOfJourney);
    }
}
