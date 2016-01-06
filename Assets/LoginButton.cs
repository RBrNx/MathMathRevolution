using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoginButton : MonoBehaviour {

	public static bool loggedIn = false;

	// Use this for initialization
	void Start () {
		if(loggedIn)
		{
			GetComponent<Assessment>().UpdateWonBadges();
			GetComponent<Assessment>().UpdateGameDesc();
			GetComponent<Assessment>().UpdateLeaderboard();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		SceneManager.LoadScene("LoginScene");
	}
}
