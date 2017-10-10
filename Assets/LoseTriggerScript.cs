using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTriggerScript : MonoBehaviour {

	public float GameEndCounter=0f;

	void OnTriggerEnter(Collider EnterObject){
		if (EnterObject.name == "Test Plate 1") {
			GameEndCounter +=1f;
		}

		if (EnterObject.name == "Test Plate 2") {
			GameEndCounter += 1f;
		}

		if (EnterObject.name == "Test Plate 3") {
			GameEndCounter +=1f;
		}
	}
}
