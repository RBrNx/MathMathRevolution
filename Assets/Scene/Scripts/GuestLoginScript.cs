﻿using UnityEngine;
using System.Collections;

public class GuestLoginScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		GetComponent<Assessment>().LoginGuest("LoginScene", "InitialLoginScene");
	}
}