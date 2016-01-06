using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

    GameObject gObj;
    Text guiTimeText;
    Text guiScoreText;
    Text guiAnswersText;
    Text[] questionArray = new Text[10];

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

        for(int i = 0, pos = 0; i < 10; i++)
        {
            if(PlayerPrefs.HasKey("Feedback " + i))
            {
                gObj = GameObject.Find("Feedback " + (pos + 1));
                questionArray[pos] = gObj.GetComponent<Text>();

                questionArray[pos].text = "#" + (i+1) + ": " + PlayerPrefs.GetString("Feedback " + i);
                pos++;
            }
        }
    }

    public void deletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
