using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject player;//samo za testiranje sa 1 igracom, to vazi i za sledeca 2

    [SerializeField] float playerJumpHeight;

    [SerializeField] int playerPos = 0;

    [SerializeField] List<GameObject> fields;//lista sa svim poljima
    GameObject fieldHolder;//gameobject u kome se nalaze sva polja

    void Start()
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//detektuje klik spacea, zameniti kockicom ili sta vec odlucimo za biranje koliko se igrac pomera
        {
            List<Vector3> positions = GeneratePositionList(2);
            if(positions.Count == 0)
            {
                return;
            }
            player.GetComponent<PlayerScript>().StartPlayerMotion(positions);
        }
    }
    List<Vector3> GeneratePositionList(int moves)//ova funkcija sluzi da napravi listu pozicija koje traba igrac da predje u zavisnosti od toga koliko polja treba da predje
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
        //TODO kad se dodaju vise igraca dodati funkcionalnost da promeni samo za onog koji je na redu
        playerPos = fieldIndex - 1;
    }
}
