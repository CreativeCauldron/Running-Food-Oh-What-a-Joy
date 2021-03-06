﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool GameStarted = false;
	public bool GameOver = false;
	public bool GameWon = false;

	public Text DisplayText;

	public GameObject Player;
	Vector3 InputVector;

	public GameObject LoseTrigger;
	public GameObject WinTrigger;

	public GameObject plateOne;
	public GameObject plateTwo;
	public GameObject plateThree;

	public Vector3 LeftPlates;
	public Vector3 RightPlates;

	public float TorqueAdjustValue=.05f;

	public Text LeftArmHint;
	public Text RightArmHint;

	// Use this for initialization
	void Start () {
		LeftPlates = new Vector3 (0f, 0f, 0f);
		RightPlates = new Vector3 (0f, 0f, 0f);

		plateOne.GetComponent<Rigidbody> ().isKinematic = true;
		plateTwo.GetComponent<Rigidbody> ().isKinematic = true;
		plateThree.GetComponent<Rigidbody> ().isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameWon == false) {
			if (GameStarted == false && GameOver == false) {
				DisplayText.text = "Welcome to the Game";
				DisplayText.text += "\n When ready press space to start";
				DisplayText.text += "\n Use WASD to move, QE will turn";
				DisplayText.text += "\n Hold Down UO to rotate the plates on the left";
				DisplayText.text += "\n Hold Down JL to rotate the plates on the right";

				LeftArmHint.text = " ";
				RightArmHint.text = " ";


				if (Input.GetKeyDown (KeyCode.Space)) {
					GameStarted = true;

					LeftArmHint.text = "<U-O>";
					RightArmHint.text = "<J-L>";

					plateOne.GetComponent<Rigidbody> ().isKinematic = false;
					plateTwo.GetComponent<Rigidbody> ().isKinematic = false;
					plateThree.GetComponent<Rigidbody> ().isKinematic = false;
				}

			} else if (GameStarted == true && GameOver == false) {
				DisplayText.text = " ";
				PlayerControls ();
				PlateControls ();

			} else if (GameStarted == true && GameOver == true) {
				DisplayText.text = "Press R to restart and try again";
				InputVector = new Vector3 (0f, 0f, 0f);

				if (Input.GetKeyDown (KeyCode.R)) {
					SceneManager.LoadScene ("Harpoons", LoadSceneMode.Single);
					GameStarted = false;
				}
			}
		} else if (GameWon == true) {
			DisplayText.text = "Yeah you did it! Can you do it again?";
			DisplayText.text += "\n Press R to see if you're right.";

			InputVector = new Vector3 (0f, 0f, 0f);

			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene ("Harpoons",LoadSceneMode.Single);
				GameStarted = false;
			}
		}

		if (LoseTrigger.GetComponent<LoseTriggerScript> ().GameEndCounter >= 3.0f) {
			GameOver = true;
		}
//		FoodOnePos= new Vector3(plateOne.GetComponent<Transform> ().position.x, FoodOne.GetComponent
//
//		FoodOne.GetComponent<Transform> ().position = FoodOnePos;
	}

	void PlayerControls (){
		float HInput = Input.GetAxis ("Horizontal");
		float VInput = Input.GetAxis ("Vertical");
		InputVector = Player.transform.right * HInput + Player.transform.forward * VInput;

		if (InputVector.magnitude > 1f) {
			InputVector = InputVector / InputVector.magnitude;
		}

		if (Input.GetKey (KeyCode.Q)) {
			Player.transform.Rotate (0f, -90f * Time.deltaTime, 0f);
		} else if (Input.GetKey (KeyCode.E)){
			Player.transform.Rotate (0f, 90f * Time.deltaTime, 0f);
		}
	}

	void PlateControls (){
		if (Input.GetKey (KeyCode.U)) {
			if (LeftPlates.x > -2.5f) {
				LeftPlates.x = -2.5f;
			} else {
				LeftPlates.x = LeftPlates.x - TorqueAdjustValue;
			}
		} else if (Input.GetKey (KeyCode.O)) {
			if (LeftPlates.x < 2.5f) {
				LeftPlates.x = 2.5f;
			} else {
				LeftPlates.x = LeftPlates.x + TorqueAdjustValue;
			}
		}

		if (Input.GetKey (KeyCode.J)) {
			if (RightPlates.x > -2.5f) {
				RightPlates.x = 2.5f;
			} else {
				RightPlates.x = RightPlates.x - TorqueAdjustValue;
			}
		} else if (Input.GetKey (KeyCode.L)) {
			if (RightPlates.x < 2.5f) {
				RightPlates.x = 2.5f;
			} else {
				RightPlates.x = RightPlates.x + TorqueAdjustValue;
			}
		}

		if (LeftPlates.x > 5.0f) {
			LeftPlates.x = 5.0f;
		} else if (LeftPlates.x < -5.0f) {
			LeftPlates.x = -5.0f;
		}

		if (RightPlates.x > 5.0f) {
			RightPlates.x = 5.0f;
		} else if (RightPlates.x < -5.0f) {
			RightPlates.x = -5.0f;
		}
	}

	void FixedUpdate (){
		Player.GetComponent<Rigidbody> ().velocity = InputVector * 11f+Physics.gravity*0.1f;

		plateOne.GetComponent<ConstantForce> ().relativeTorque = LeftPlates;
		plateTwo.GetComponent<ConstantForce> ().relativeTorque = LeftPlates;
		plateThree.GetComponent<ConstantForce> ().relativeTorque = RightPlates;
	}
}
