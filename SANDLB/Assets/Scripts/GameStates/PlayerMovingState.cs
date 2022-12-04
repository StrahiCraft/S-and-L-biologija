using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : GameState
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
        if(playerState != "idle")
        {
            return;
        }
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().ChangeGameState(new IdleGameState());
    }
}
