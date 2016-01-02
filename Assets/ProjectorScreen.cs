using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectorScreen : MonoBehaviour {

	public TextAsset questionsFile;

	// Use this for initialization
	void Start () {
		Dictionary<string, List<Question>> questions = Question.loadQuestions(questionsFile.text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
