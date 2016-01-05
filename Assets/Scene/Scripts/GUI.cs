using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI : MonoBehaviour {

    float audioLength;
    GameObject gObj;
    ChangeScene csScript;
    Text guiTimeText;
    Text guiScoreText;
    Text guiAnswersText;

    int correctAnswers;
    int questions = 0;
    int score;
    int difference;
    int levelSoundIndex;


    // Use this for initialization
    void Start ()
    {
        levelSoundIndex = PlayerPrefs.GetInt("levelSoundIndex");
        gObj = GameObject.Find("_Manager");
        csScript = gObj.GetComponent<ChangeScene>();

        if(levelSoundIndex == 1 || levelSoundIndex == 2 || levelSoundIndex == 3)
        {
            audioLength = csScript.lvl1Music.clip.length;
            difference = 25000 - (int)audioLength * 50;
        }
        else if(levelSoundIndex == 4 || levelSoundIndex == 5 || levelSoundIndex == 6)
        {
            audioLength = csScript.lvl2Music.clip.length;
            difference = 25000 - (int)audioLength * 50;
        }
        else if(levelSoundIndex == 7 || levelSoundIndex == 8 || levelSoundIndex == 9)
        {
            audioLength = csScript.lvl3Music.clip.length;
            difference = 25000 - (int)audioLength * 50;
        }

        gObj = GameObject.Find("TimeText");
        guiTimeText = gObj.GetComponent<Text>();

        gObj = GameObject.Find("ScoreText");
        guiScoreText = gObj.GetComponent<Text>();

        gObj = GameObject.Find("AnswersText");
        guiAnswersText = gObj.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        //Sets up time remaining text
        if ((csScript.lvl1Music.time > 0.1 || csScript.lvl2Music.time > 0.1 || csScript.lvl3Music.time > 0.1) && audioLength > 0)
        {
            audioLength = (audioLength - Time.deltaTime);
            int seconds = (int)audioLength % 60;
            int minutes = (int)audioLength / 60;
            guiTimeText.text = "Time Left: " + minutes + "m " + seconds + "s";
        }
        else if(audioLength > 0)
        {
            int seconds = (int)audioLength % 60;
            int minutes = (int)audioLength / 60;
            guiTimeText.text = "Time Left: " + minutes + "m " + seconds + "s";
        }        

        if(audioLength > 0 && questions < 10)
        {
            /*if (Input.GetKeyUp("u"))
            {
                correctAnswers++;
                questions++;
            }
            else if(Input.GetKeyUp("i"))
            {
                questions++;
            }*/

            score = ((PlayerPrefs.GetInt("correctAnswers") + 1) * (int)audioLength) * 50 + difference;
            PlayerPrefs.SetInt("Score", score);
        }

        guiScoreText.text = "Score: " + PlayerPrefs.GetInt("Score");

        PlayerPrefs.SetInt("timeLeft", (int)audioLength);
        //PlayerPrefs.SetInt("correctAnswers", correctAnswers);
        //PlayerPrefs.SetInt("questionsAsked", questions);
        guiAnswersText.text = "Answers: " + PlayerPrefs.GetInt("correctAnswers") + "/" + PlayerPrefs.GetInt("questionsAsked");
    }
}
