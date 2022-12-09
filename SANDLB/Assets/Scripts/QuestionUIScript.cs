using UnityEngine;
using TMPro;

public class QuestionUIScript : MonoBehaviour
{
    [SerializeField] TMP_Text questionText;
    bool correctQuestionAnswer = true;
    public void ChooseQuestion()
    {
        QuestionData newQuestion = GameObject.FindGameObjectWithTag("QuestionGenerator").
            GetComponent<QuestionGeneratorScript>().ReturnRandomQuestion();
        questionText.text = newQuestion.questionText;
        correctQuestionAnswer = newQuestion.answer;
    }
    public void TrueButtonPressed()
    {
        AnswerQuestion(true);
    }
    public void FalseButtonPressed()
    {
        AnswerQuestion(false);
    }
    void AnswerQuestion(bool chosenAnswer)
    {
        if (chosenAnswer != correctQuestionAnswer)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().ChangeGameState(new IdleGameState());
        }
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().RollDice();
    }
}
