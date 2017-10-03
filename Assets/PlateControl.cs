using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateControl : MonoBehaviour {

	public GameObject plateOne;
	public GameObject plateTwo;
	public GameObject plateThree;

	public Vector3 LeftPlates;
	public Vector3 RightPlates;

	public float TorqueAdjustValue=.05f;

	// Use this for initialization
	void Start () {
		LeftPlates = new Vector3 (0f, 0f, 0f);
		RightPlates = new Vector3 (0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.U)) {
			LeftPlates.x=LeftPlates.x-TorqueAdjustValue;
		} else if (Input.GetKey (KeyCode.O)) {
			LeftPlates.x=LeftPlates.x+TorqueAdjustValue;
		}

		if (Input.GetKey (KeyCode.J)) {
			RightPlates.x=RightPlates.x-TorqueAdjustValue;
		} else if (Input.GetKey (KeyCode.L)) {
			RightPlates.x=RightPlates.x+TorqueAdjustValue;
		}
	}

	void FixedUpdate (){
		plateOne.GetComponent<ConstantForce> ().torque = LeftPlates;
		plateTwo.GetComponent<ConstantForce> ().torque = LeftPlates;
		plateThree.GetComponent<ConstantForce> ().torque = RightPlates;
	}
}
