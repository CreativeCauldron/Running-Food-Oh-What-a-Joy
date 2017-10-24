using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalArrowBob : MonoBehaviour {

	public Vector3 Pos1;
	public Vector3 Pos2;

	public bool Pos1or2;

	// Use this for initialization
	void Start () {
		Pos1or2 = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Pos1or2 == true) {
			if (this.gameObject.GetComponent<Transform> ().position.y > Pos2.y) {
				this.transform.Translate (0f, 1f * Time.deltaTime, 0f);
			} else {
				Pos1or2 = false;
			}
		} else if (Pos1or2 == false) {
			if (this.gameObject.GetComponent<Transform> ().position.y < Pos1.y) {
				this.transform.Translate (0f, -1f * Time.deltaTime, 0f);
			} else {
				Pos1or2 = true;
			}
		}
	}
}
