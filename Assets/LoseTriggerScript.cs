using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTriggerScript : MonoBehaviour {

	public float GameEndCounter=0f;
	public AudioSource FirstSource;
	public AudioSource SecondSource;
	public AudioSource ThirdSource;



	void OnTriggerEnter(Collider EnterObject){
		if (EnterObject.name == "Test Plate 1") {
			GameEndCounter +=1f;
			Destroy(EnterObject.gameObject);
			FirstSource.Play ();
		}

		if (EnterObject.name == "Test Plate 2") {
			GameEndCounter += 1f;
			Destroy(EnterObject.gameObject);
			SecondSource.Play ();
		}

		if (EnterObject.name == "Test Plate 3") {
			GameEndCounter +=1f;
			Destroy(EnterObject.gameObject);
			ThirdSource.Play ();
		}

		if (EnterObject.name == "Test Food 1" || EnterObject.name == "Test Food 2" || EnterObject.name == "Test Food 3" || EnterObject.name == "Test Food 4" || EnterObject.name == "Test Food 5" || EnterObject.name == "Test Food 6") {
			Destroy (EnterObject.gameObject);
		}
	}
}
