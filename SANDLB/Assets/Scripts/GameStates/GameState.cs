using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    public abstract void GetQuestion(GameObject questionUI);
    public abstract void RollDice(GameObject diceCamera);
    public abstract void UpdateState(int diceNumber, string playerState);
    public abstract void OnStateEnter();
}
