using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectorScreen : MonoBehaviour {

    Dictionary<string, List<Question>> questions;
    public TextAsset questionsFile;
    public int chosenTopic;
    int questionNumber = 0;
    GameObject gObj;
    TextMesh question;
    TextMesh answerOne;
    TextMesh answerTwo;
    TextMesh answerThree;
    TextMesh answerFour;

    // Use this for initialization
    void Start () {
		questions = Question.loadQuestions(questionsFile.text);
        gObj = GameObject.Find("Question");
        question = gObj.GetComponent<TextMesh>();

        gObj = GameObject.Find("Answer 1");
        answerOne = gObj.GetComponent<TextMesh>();

        gObj = GameObject.Find("Answer 2");
        answerTwo = gObj.GetComponent<TextMesh>();

        gObj = GameObject.Find("Answer 3");
        answerThree = gObj.GetComponent<TextMesh>();

        gObj = GameObject.Find("Answer 4");
        answerFour = gObj.GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
