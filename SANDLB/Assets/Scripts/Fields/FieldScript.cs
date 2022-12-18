using UnityEngine;

public class FieldScript : MonoBehaviour
{

    int positionCase = 0;

    [SerializeField] Vector3[] twoPlayersOnFieldPositionOffset;
    [SerializeField] Vector3[] threePlayersOnFieldPositionOffset;
    [SerializeField] Vector3[] fourPlayersOnFieldPositionOffset;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        other.transform.parent = transform;
        positionCase++;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>().Play("PlayerLand");
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        other.transform.parent = null;
        positionCase--;
    }
    private void OnTriggerStay(Collider other)
    {
        if(positionCase != 0)
        {
            CheckPlayerPositionCase();
        }
    }
    void CheckPlayerPositionCase()
    {
        if (gameObject.transform.GetChild(positionCase).GetComponent<PlayerScript>().GetPlayerState() != "idle")
        {
            return;
        }
        switch (positionCase)
        {
            case 1:
                gameObject.transform.GetChild(1).transform.position = transform.position;
                break;
            case 2:
                SetPlayersPositions(twoPlayersOnFieldPositionOffset);
                break;
            case 3:
                SetPlayersPositions(threePlayersOnFieldPositionOffset);
                break;
            case 4:
                SetPlayersPositions(fourPlayersOnFieldPositionOffset);
                break;
            default:
                break;
        }
    }
    void SetPlayersPositions(Vector3[] playerPositionOffsets)
    {
        int playerCount = playerPositionOffsets.Length;
        for(int playerIndex = 0; playerIndex < playerCount; playerIndex++)
        {
            gameObject.transform.GetChild(playerIndex + 1).transform.localPosition = playerPositionOffsets[playerIndex] / transform.localScale.x;
        }
    }
}
