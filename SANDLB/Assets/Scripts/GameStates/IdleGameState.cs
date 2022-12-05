using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGameState : GameState
{
    public override void GetQuestion(GameObject questionUI)
    {
        questionUI.SetActive(true);
        questionUI.GetComponent<QuestionUIScript>().ChooseQuestion();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().ChangeGameState(new QuestionState());
    }
    public override void RollDice(GameObject diceCamera)
    {
        return;
    }
    public override void UpdateState(int diceNumber, string playerState)
    {
        return;
    }
    public override void OnStateEnter()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().FreeLookCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().NextTurn();
    }
}
