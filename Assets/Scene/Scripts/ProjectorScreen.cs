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
		bool[] answerAdded = { false, false, false, false };

    // Use this for initialization
    void Start () {
				answers = new TextMesh[4];
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
						ChangeQuestion();
        }

        if (questionChange)
        {
            int correctCount = questions[chosenTopic][questionNumber].correctAnswers.Count;
            int incorrectCount = 4 - correctCount;
            question.text = questions[chosenTopic][questionNumber].question;
            int correctFilled = 0, incorrectFilled = 0;

            while (correctFilled != correctCount || incorrectFilled != incorrectCount)
            {
                int random = Random.Range(0, 4);
                if(!answerAdded[random])
                {
                    if(correctFilled != correctCount)
                    {
                        answers[random].text = questions[chosenTopic][questionNumber].correctAnswers[correctFilled];
                        correctFilled++;
												answerAdded[random] = true;
                    }
                    else if (incorrectFilled != incorrectCount)
                    {
                        answers[random].text = questions[chosenTopic][questionNumber].incorrectAnswers[incorrectFilled];
                        incorrectFilled++;
												answerAdded[random] = true;
										}
                }
            }

            questionChange = false;
        }
    }

		public void ChangeQuestion()
		{
			questionChange = true;
			answerAdded[0] = false;
			answerAdded[1] = false;
			answerAdded[2] = false;
			answerAdded[3] = false;
		}
}
