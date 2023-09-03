using UnityEngine;

public class QuestionState : GameState
{
    public override void GetQuestion(GameObject questionUI, GameObject timer)
    {
        return;
    }
    public override void RollDice(GameObject diceCamera)
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>().Stop("Timer");
        diceCamera.SetActive(true);
        diceCamera.GetComponentInChildren<DiceScript>().ThrowDice();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().ChangeGameState(new DiceRollState());
    }
    public override void UpdateState(int diceNumber, string playerState)
    {
        return;
    }
    public override void OnStateEnter()
    {
        Scoreboard.Instance.SetCanvasActive(false);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>().Play("Timer");
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().FreeLookCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public override void OnStateExit()
    {
        Scoreboard.Instance.SetCanvasActive(true);
    }
}
