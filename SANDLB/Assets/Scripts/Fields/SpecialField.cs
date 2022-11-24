using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialField : MonoBehaviour
{
    [SerializeField] int fieldLeadsTo;
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        if (other.GetComponent<PlayerScript>().GetPlayerState() == "idle")
        {
            List<Vector3> positions = new List<Vector3>();
            GameObject gameManagerReference = GameObject.FindGameObjectWithTag("GameManager");

            positions.Add(transform.position);//pozicija trenutnog polja
            Vector3 endPos = gameManagerReference.GetComponent<GameManagerScript>().GetFieldPosition(fieldLeadsTo);
            positions.Add(gameManagerReference.GetComponent<GameManagerScript>().GenerateJumpPeak(positions[0], endPos));
            positions.Add(endPos);//pozicija polja gde ce igrac da zavrsi

            other.GetComponent<PlayerScript>().StartPlayerMotion(positions);
            gameManagerReference.GetComponent<GameManagerScript>().SetPlayerPos(fieldLeadsTo);
        }
    }
}
