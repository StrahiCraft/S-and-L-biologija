using UnityEngine;

public class DiceRollState : GameState
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
        if(diceNumber == 0)
        {
            return;
        }
        if(diceNumber == 6) 
        {
            GameManagerScript.Instance.PlayerPlaysAgain();
        }
        GameObject DiceCamera = GameObject.FindGameObjectWithTag("DiceCamera");
        DiceCamera.SetActive(false);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().ChangeGameState(new PlayerMovingState());
    }
    public override void OnStateEnter()
    {
        GameObject.FindGameObjectWithTag("Timer").SetActive(false);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().FreeLookCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void OnStateExit()
    {
        return;
    }
}
