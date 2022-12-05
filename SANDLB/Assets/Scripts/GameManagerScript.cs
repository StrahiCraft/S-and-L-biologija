using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject diceCamera;
    [SerializeField] GameObject questionUI;
    public GameObject FreeLookCamera
    {
        get;
        set;
    }

    [SerializeField] GameObject[] players;
    int currentTurn = -1;

    [SerializeField] float playerJumpHeight;

    int[] playerFieldIndexes = new int[4];

    List<GameObject> fields = new List<GameObject>();//lista sa svim poljima
    GameObject fieldHolder;//gameobject u kome se nalaze sva polja

    GameState currentGameState;

    void Start()
    {
        FreeLookCamera = GameObject.FindGameObjectWithTag("FreeLookCamera");
        ChangeGameState(new IdleGameState());
        HandleFields();
        for(int i = 0; i < 4; i++)
        {
            playerFieldIndexes[i] = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentGameState.GetQuestion(questionUI);
        }
        int moveCount = diceCamera.activeInHierarchy? diceCamera.GetComponentInChildren<DiceScript>().DiceValue : 0;
        List<Vector3> positions = GeneratePositionList(moveCount);
        players[currentTurn % 4].GetComponent<PlayerScript>().StartPlayerMotion(positions);
        currentGameState.UpdateState(moveCount, players[currentTurn % 4].GetComponent<PlayerScript>().GetPlayerState());
    }

    void HandleFields()
    {
        //-------------------------------------------------------------------------------
        //ova sekcija sluzi za ubacivanje svih polja u sceni u listu polja
        fieldHolder = GameObject.FindGameObjectWithTag("FieldHolder");
        int i = 0;

        while (i < fieldHolder.transform.childCount)
        {
            fields.Add(fieldHolder.transform.GetChild(i).gameObject);
            fields[i].name = (i + 1).ToString();//ovo moze da se skloni nego je tu samo radi lakseg razumevanja koje je koje polje
            i++;
        }
        //-------------------------------------------------------------------------------
    }

    public void ChangeGameState(GameState newGameState)
    {
        currentGameState = newGameState;
        currentGameState.OnStateEnter();
    }
    List<Vector3> GeneratePositionList(int moveCount)//ova funkcija sluzi da napravi listu pozicija koje traba igrac da predje u zavisnosti od toga koliko polja treba da predje
    {
        if(moveCount == 0)
        {
            return new List<Vector3>();
        }
        if(players[currentTurn % 4].GetComponent<PlayerScript>().GetPlayerState() == "moving")
        {
            return new List<Vector3>();
        }
        if(playerFieldIndexes[currentTurn % 4] + moveCount >= fields.Count)
        {
            return new List<Vector3>();
        }
        List<Vector3> positions = new List<Vector3>();

        for(int moveIndex = 0; moveIndex < moveCount; moveIndex++)
        {
            positions.Add(fields[playerFieldIndexes[currentTurn % 4]].transform.position);
            positions.Add(GenerateJumpPeak(fields[playerFieldIndexes[currentTurn % 4]].transform.position,
                fields[playerFieldIndexes[currentTurn % 4] + 1].transform.position));
            playerFieldIndexes[currentTurn % 4]++;
        }
        positions.Add(fields[playerFieldIndexes[currentTurn % 4]].transform.position);
        return positions;
    }
    public Vector3 GenerateJumpPeak(Vector3 pos1, Vector3 pos2)//ova funkcija sluzi da generise tacku za playerJumpHeight iznad viseg od dva polja
    {
        Vector3 jumpPeak = (pos1 + pos2) / 2;
        jumpPeak.y = pos2.y + playerJumpHeight;
        if (pos1.y > pos2.y)
        {
            jumpPeak.y = pos1.y + playerJumpHeight;
        }
        return jumpPeak;
    }
    public Vector3 GetFieldPosition(int fieldIndex)//vraca poziciju polja sa ovim indexom
    {
        return fields[fieldIndex - 1].transform.position;
    }
    public void SetPlayerPos(int fieldIndex)//menja index igraceve pozicije
    {
        playerFieldIndexes[currentTurn % 4] = fieldIndex - 1;
    }

    public void RollDice()
    {
        questionUI.SetActive(false);
        currentGameState.RollDice(diceCamera);
    }

    public void NextTurn()
    {
        currentTurn++;
        FreeLookCamera.GetComponent<CinemachineFreeLook>().Follow = players[currentTurn % 4].transform;
        FreeLookCamera.GetComponent<CinemachineFreeLook>().LookAt = players[currentTurn % 4].transform;
    }
}
