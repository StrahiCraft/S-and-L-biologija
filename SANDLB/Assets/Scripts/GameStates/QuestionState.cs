using UnityEngine;

public class QuestionState : GameState
{
    public override void GetQuestion(GameObject questionUI, GameObject timer)
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
    public override void OnStateEnter()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().FreeLookCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
