using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

    GameObject gObj;
    Text guiTimeText;
    Text guiScoreText;
    Text guiAnswersText;

    // Use this for initialization
    void Start () {

        gObj = GameObject.Find("TimeText");
        guiTimeText = gObj.GetComponent<Text>();

        gObj = GameObject.Find("ScoreText");
        guiScoreText = gObj.GetComponent<Text>();

        gObj = GameObject.Find("AnswersText");
        guiAnswersText = gObj.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

        //displays remaining time
        int timeLeft = PlayerPrefs.GetInt("timeLeft");
        int seconds = timeLeft % 60;
        int minutes = timeLeft / 60;
        guiTimeText.text = "Time Left: " + minutes + "m " + seconds + "s";

        //displays player score
        guiScoreText.text = "Score: " + PlayerPrefs.GetInt("Score");

        //displays correct answer of possible questions
        guiAnswersText.text = "Answers: " + PlayerPrefs.GetInt("correctAnswers") + "/" + PlayerPrefs.GetInt("questionsAsked");
    }

    public void deletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
