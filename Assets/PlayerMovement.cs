using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w")){
			transform.Translate((Vector3.forward) * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey ("s")) {
			transform.Translate ((Vector3.back) * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey ("a")) {
			transform.Translate ((Vector3.left) * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey ("d")) {
			transform.Translate ((Vector3.right) * moveSpeed * Time.deltaTime);
		}
	}
}
