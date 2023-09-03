using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public static Scoreboard Instance;
    [SerializeField] GameObject canvas;
    [SerializeField] TMP_Text scoreboardText;

    public struct PlayerScoreboard
    {
        public int playerId;
        public int playerPosition;
        public Color playerColor;
        public bool isPlayersTurn;
    }

    Color[] playerColors = new Color[4];

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }

    private void Start()
    {
        playerColors[0] = Color.red;
        playerColors[1] = Color.yellow;
        playerColors[2] = Color.green;
        playerColors[3] = Color.blue;
    }

    PlayerScoreboard[] SortScoreboard(PlayerScoreboard[] playerScoreboard)
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = i + 1;j < 4; j++)
            {
                if (playerScoreboard[i].playerPosition < playerScoreboard[j].playerPosition)
                {
                    PlayerScoreboard ps = playerScoreboard[i];
                    playerScoreboard[i] = playerScoreboard[j];
                    playerScoreboard[j] = ps;
                }
            }
        }
        return playerScoreboard;
    }

    public void GenerateScoreboard(int turn, int[] playerPositions)
    {
        PlayerScoreboard[] playerScoreboard = new PlayerScoreboard[4];

        for(int i = 0; i < 4; i++)
        {
            playerScoreboard[i] = new PlayerScoreboard();
            playerScoreboard[i].playerId = i + 1;
            playerScoreboard[i].playerPosition = playerPositions[i];
            playerScoreboard[i].playerColor = playerColors[i];
            playerScoreboard[i].isPlayersTurn = turn % 4 == i;
        }
        playerScoreboard = SortScoreboard(playerScoreboard);

        scoreboardText.text = GenerateScoreboardString(playerScoreboard);
    }

    string GenerateScoreboardString(PlayerScoreboard[] playerScoreboard)
    {
        string scoreboard = "";
        for(int i = 0; i < 4; i++)
        {
            scoreboard += $"<color=#{ColorUtility.ToHtmlStringRGB(playerScoreboard[i].playerColor)}>{i + 1}. Player {playerScoreboard[i].playerId} Position" +
                $" {playerScoreboard[i].playerPosition} </color>";

            if (playerScoreboard[i].isPlayersTurn)
            {
                scoreboard += " *";
            }
            scoreboard += "\n";
        }
        return scoreboard;
    }

    public void SetCanvasActive(bool active)
    {
        canvas.SetActive(active);
    }
}
