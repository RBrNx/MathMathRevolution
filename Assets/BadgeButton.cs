using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BadgeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button>().interactable = LoginButton.loggedIn;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		SceneManager.LoadScene("BadgeScene");
	}
}
