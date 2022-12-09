using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : GameState
{
    public override void GetQuestion(GameObject questionUI, GameObject timer)
    {
        return;
    }
    public override void RollDice(GameObject diceCamera)
    {
        return;
    }
    public override void UpdateState(int diceNumber, string playerState)
    {
        if(playerState != "idle")
        {
            return;
        }
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().ChangeGameState(new IdleGameState());
    }
    public override void OnStateEnter()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().FreeLookCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
