using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionState : GameState
{
    public override void GetQuestion(GameObject questionUI)
    {
        return;
    }
    public override void RollDice(GameObject diceCamera)
    {
        diceCamera.SetActive(true);
        diceCamera.GetComponentInChildren<DiceScript>().ThrowDice();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().ChangeGameState(new DiceRollState());
    }
    public override void UpdateState(int diceNumber, string playerState)
    {
        return;
    }
}
