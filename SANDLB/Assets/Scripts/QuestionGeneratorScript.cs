using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuestionGeneratorScript : MonoBehaviour
{
    [SerializeField] QuestionList questionList = new QuestionList();
    void Awake()
    {
        string json = File.ReadAllText(Application.dataPath + "/pitanja.json");
        questionList = JsonUtility.FromJson<QuestionList>(json);
    }
    public QuestionData ReturnRandomQuestion()
    {
        int chosenQuestionIndex = Random.Range(0, questionList.questions.Length);
        return questionList.questions[chosenQuestionIndex];
    }
}
[System.Serializable]
public class QuestionList
{
    public QuestionData[] questions;
}
[System.Serializable]
public class QuestionData
{
    public string questionText;
    public bool answer;
}