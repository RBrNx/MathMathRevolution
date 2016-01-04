using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectorScreen : MonoBehaviour {

    Dictionary<string, List<Question>> questions;
    public TextAsset questionsFile;
    string chosenTopic = "Topic 1 - Easy";
    int questionNumber = 0;
    bool questionChange = true;
    GameObject gObj;
    TextMesh question;
    TextMesh[] answers;

    // Use this for initialization
    void Start () {
		questions = Question.loadQuestions(questionsFile.text);
        gObj = GameObject.Find("Question");
        question = gObj.GetComponent<TextMesh>();

        gObj = GameObject.Find("Answer 1");
        answers[0] = gObj.GetComponent<TextMesh>();

        gObj = GameObject.Find("Answer 2");
        answers[1] = gObj.GetComponent<TextMesh>();

        gObj = GameObject.Find("Answer 3");
        answers[2] = gObj.GetComponent<TextMesh>();

        gObj = GameObject.Find("Answer 4");
        answers[3] = gObj.GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp("space"))
        {
            questionNumber++;
            questionChange = true;
        }

        if (questionChange)
        {
            int correctCount = questions[chosenTopic][questionNumber].correctAnswers.Count;
            int incorrectCount = 4 - correctCount;
            question.text = questions[chosenTopic][questionNumber].question;
            int correctFilled = 0, incorrectFilled = 0;

            while (correctFilled != correctCount && incorrectFilled != incorrectCount)
            {
                int random = Random.Range(0, 3);
                if(answers[random] == null)
                {
                    if(correctFilled != correctCount)
                    {
                        answers[random].text = questions[chosenTopic][questionNumber].correctAnswers[correctFilled];
                        correctFilled++;
                    }
                    else if (incorrectFilled != incorrectCount)
                    {
                        answers[random].text = questions[chosenTopic][questionNumber].correctAnswers[incorrectFilled];
                        incorrectFilled++;
                    }
                }
            }

            questionChange = false;
        }
    }
}
