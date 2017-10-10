using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {

	public GameObject GameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider EnterObject){
		if (EnterObject.name == "PlayerCharacter") {
			GameManager.GetComponent<GameManager> ().GameWon = true;
		}
	}
}
