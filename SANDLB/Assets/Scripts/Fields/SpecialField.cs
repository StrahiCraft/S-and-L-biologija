using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialField : MonoBehaviour
{
    [SerializeField] int fieldLeadsTo;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        StartCoroutine(StartPlayerMovement(other));
    }
    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    IEnumerator StartPlayerMovement(Collider other)
    {
        yield return new WaitForSeconds(1f);
        other.GetComponent<PlayerScript>().StopAllCoroutines();

        List<Vector3> positions = new List<Vector3>();
        GameObject gameManagerReference = GameObject.FindGameObjectWithTag("GameManager");

        positions.Add(transform.position);//pozicija trenutnog polja
        Vector3 endPos = gameManagerReference.GetComponent<GameManagerScript>().GetFieldPosition(fieldLeadsTo);
        positions.Add(gameManagerReference.GetComponent<GameManagerScript>().GenerateJumpPeak(positions[0], endPos));
        positions.Add(endPos);//pozicija polja gde ce igrac da zavrsi

        other.GetComponent<PlayerScript>().ChangeState(new IdleState());
        other.GetComponent<PlayerScript>().StartPlayerMotion(positions);
        gameManagerReference.GetComponent<GameManagerScript>().SetPlayerPos(fieldLeadsTo);
    }
}
