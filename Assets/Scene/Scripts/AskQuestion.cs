using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AskQuestion : MonoBehaviour {

    Dictionary<string, List<Question>> questions;
    public TextAsset questionsFile;
    string chosenTopic;
    int questionNumber = 0;
    bool questionChange = true;
    GameObject gObj;
    TextMesh question;
    TextMesh[] answers;
	bool[] answerAdded = { false, false, false, false };
    int correctCount;
    int incorrectCount;
    float timer = 3;

    int pressurePadPressed;
    bool pressurePadReleased = true;
    int correctAnswers;

    int answeredCorrectly;
    int questionsAsked;
    int padCount = 0;

    // Use this for initialization
    void Start () {
        chosenTopic = PlayerPrefs.GetString("ChosenTopic");

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

        Debug.Log("questionNumber: " + questionNumber + "\n"
            + "correctAnswers: " + correctAnswers + "\n"
            + "answeredCorrectly: " + answeredCorrectly + "\n"
            + "questionsAsked: " + questionsAsked + "\n"
            + "playerQA: " + PlayerPrefs.GetInt("questionsAsked") + "\n"
            + "timeLeft: " + PlayerPrefs.GetInt("timeLeft"));
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("questionsAsked") == 10 || PlayerPrefs.GetInt("timeLeft") == 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            CheckQuestions();
            CheckAnswers();
        }
        if(timer <= 0)
        {
            Application.LoadLevel(3);
        }

    }

	public void ChangeQuestion()
	{
        questionNumber++;
        questionChange = true;
		answerAdded[0] = false;
		answerAdded[1] = false;
		answerAdded[2] = false;
		answerAdded[3] = false;
	}

    public void setPressurePad(int padID)
    {
        pressurePadPressed = padID;
    }

    public void setPressurePadReleased(bool padRelease)
    {
        pressurePadReleased = padRelease;
    }

    public void setChosenTopic(string topic)
    {
        chosenTopic = topic;
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void CheckQuestions()
    {
        if (questionChange)
        {
            padCount = 0;
            correctAnswers = 0;
            
            correctCount = questions[chosenTopic][questionNumber].correctAnswers.Count;
            incorrectCount = 4 - correctCount;
            question.text = questions[chosenTopic][questionNumber].question;
            int correctFilled = 0, incorrectFilled = 0;

            while (correctFilled != correctCount || incorrectFilled != incorrectCount)
            {
                int random = Random.Range(0, 4);
                if (!answerAdded[random])
                {
                    if (correctFilled != correctCount)
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

    void CheckAnswers()
    {
        if(pressurePadReleased && pressurePadPressed != 0)
        {
            for(int i = 0; i < correctCount; i++)
            {
                if(answers[pressurePadPressed - 1].text == questions[chosenTopic][questionNumber].correctAnswers[i])
                {
                    correctAnswers++;
                }
            }
            padCount++;
            pressurePadPressed = 0;

            if (correctAnswers != correctCount && padCount == correctCount)
            {
                questionsAsked++;
                PlayerPrefs.SetInt("questionsAsked", questionsAsked);
                ChangeQuestion();
            }
            else if (correctAnswers == correctCount && padCount == correctCount)
            {
                answeredCorrectly++;
                questionsAsked++;
                PlayerPrefs.SetInt("questionsAsked", questionsAsked);
                PlayerPrefs.SetInt("correctAnswers", answeredCorrectly);
                ChangeQuestion();
            }
        }
    }
}
