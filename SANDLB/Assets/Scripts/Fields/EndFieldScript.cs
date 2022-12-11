using UnityEngine;
using TMPro;

public class EndFieldScript : MonoBehaviour
{
    [SerializeField] GameObject gameEndUI;
    [SerializeField] TMP_Text victoryText;
    private void OnTriggerEnter(Collider other)
    {
        gameEndUI.SetActive(true);
        victoryText.text = other.name + " je pobednik!";
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().ChangeGameState(new GameEndState());
    }
}
