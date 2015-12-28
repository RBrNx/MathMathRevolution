using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w") || Input.GetKey("up")){
			transform.Translate((Vector3.forward) * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey ("s") || Input.GetKey("down")) {
			transform.Translate ((Vector3.back) * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey ("a") || Input.GetKey("left")) {
			transform.Translate ((Vector3.left) * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey ("d") || Input.GetKey("right")) {
			transform.Translate ((Vector3.right) * moveSpeed * Time.deltaTime);
		}
	}
}
