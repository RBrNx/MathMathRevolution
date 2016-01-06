using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UsrnmPswrdLoginButton : MonoBehaviour {

	public InputField usernameInput, passwordInput;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		GetComponent<Assessment>().LoginStudent(usernameInput.text, passwordInput.text, "StudentLoginScene", "InitialLoginScene", "MainMenu");
	}
}
