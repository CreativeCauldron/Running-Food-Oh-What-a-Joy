using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour {

	public GameObject GameManager;
	public AudioSource WinSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider EnterObject){
		if (EnterObject.name == "PlayerCharacter") {
			GameManager.GetComponent<GameManager> ().GameWon = true;
			WinSource.Play ();
		}
	}
}
