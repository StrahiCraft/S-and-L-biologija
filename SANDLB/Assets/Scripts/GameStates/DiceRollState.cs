using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRollState : GameState
{
    public override void GetQuestion(GameObject questionUI)
    {
        return;
    }
    public override void RollDice(GameObject diceCamera)
    {
        return;
    }
    public override void UpdateState(int diceNumber, string playerState)
    {
        if(diceNumber == 0)
        {
            return;
        }
        GameObject DiceCamera = GameObject.FindGameObjectWithTag("DiceCamera");
        DiceCamera.SetActive(false);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().ChangeGameState(new PlayerMovingState());
    }
    public override void OnStateEnter()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().FreeLookCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
