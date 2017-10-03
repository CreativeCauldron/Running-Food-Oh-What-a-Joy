using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Vector3 InputVector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float HInput = Input.GetAxis ("Horizontal");
		float VInput = Input.GetAxis ("Vertical");
		InputVector = transform.right * HInput + transform.forward * VInput;

		if (InputVector.magnitude > 1f) {
			InputVector = InputVector / InputVector.magnitude;
		}

		if (Input.GetKey (KeyCode.Q)) {
				transform.Rotate (0f, 90f * Time.deltaTime, 0f);
		} else if (Input.GetKey (KeyCode.E)){
				transform.Rotate (0f, 90f * Time.deltaTime, 0f);
		}
	}

	void FixedUpdate (){
		GetComponent<Rigidbody> ().velocity = InputVector * 5f+Physics.gravity*0.1f;
	}
}
