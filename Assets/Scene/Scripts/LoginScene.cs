using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginScene : MonoBehaviour {

	public Text errorText;

	// Use this for initialization
	void Start ()
	{
		errorText.enabled = EngAGe.E.getErrorCode() > 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
