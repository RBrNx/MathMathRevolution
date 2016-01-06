using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoggedInTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(LoginButton.loggedIn)
		{
			Text text = GetComponent<Text>();
			text.text = "Logged In";
			text.color = Color.green;
		}
		else
		{
			Text text = GetComponent<Text>();
			text.text = "Not Logged In";
			text.color = Color.red;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
