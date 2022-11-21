using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject player;//samo za testiranje sa 1 igracom

    [SerializeField] float playerJumpHeight;

    int playerPos = 0;

    [SerializeField] List<GameObject> fields;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerPos += player.GetComponent<PlayerScript>().MoveToNextField();
            player.GetComponent<PlayerScript>().StartPlayerMotion(fields[playerPos].transform.position);
        }
    }
}
