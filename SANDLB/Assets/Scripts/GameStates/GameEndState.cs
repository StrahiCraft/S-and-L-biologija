using UnityEngine;

public class GameEndState : GameState
{
    public override void OnStateEnter()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public override void RollDice(GameObject diceCamera)
    {
        return;
    }
    public override void UpdateState(int diceNumber, string playerState)
    {
        return;
    }
    public override void GetQuestion(GameObject questionUI, GameObject timer)
    {
        return;
    }

    public override void OnStateExit()
    {
        return;
    }
}
