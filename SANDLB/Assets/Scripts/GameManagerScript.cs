using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject player;//samo za testiranje sa 1 igracom

    [SerializeField] float playerJumpHeight;

    [SerializeField] int playerPos = 0;

    [SerializeField] List<GameObject> fields;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<Vector3> positions = GeneratePositionList(4);
            if(positions.Count == 0)
            {
                return;
            }
            player.GetComponent<PlayerScript>().StartPlayerMotion(positions);
        }
    }
    List<Vector3> GeneratePositionList(int moves)
    {
        if(player.GetComponent<PlayerScript>().GetPlayerState() == "moving")
        {
            return new List<Vector3>();
        }
        List<Vector3> positions = new List<Vector3>();
        for(int i = 0; i < moves; i++)
        {
            positions.Add(fields[playerPos].transform.position);
            positions.Add(GenerateJumpPeak(fields[playerPos].transform.position, fields[playerPos + 1].transform.position));
            playerPos++;
        }
        positions.Add(fields[playerPos].transform.position);
        return positions;
    }
    Vector3 GenerateJumpPeak(Vector3 pos1, Vector3 pos2)
    {
        Vector3 jumpPeak = (pos1 + pos2) / 2;
        jumpPeak.y = pos2.y + playerJumpHeight;
        if (pos1.y > pos2.y)
        {
            jumpPeak.y = pos1.y + playerJumpHeight;
        }
        return jumpPeak;
    }
}
