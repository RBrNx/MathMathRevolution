using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetPlayerDetails : MonoBehaviour {

	public InputField nameInput, ageInput;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		GetComponent<Assessment>().SetNameAndAge(nameInput.text, ageInput.text);
		SceneManager.LoadScene("LoginScene");
	}
}
