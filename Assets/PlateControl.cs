using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateControl : MonoBehaviour {

	Rigidbody ThisBody;
	bool XPosOn;
	bool ZPosOn;

	// Use this for initialization
	void Start () {
		ThisBody = this.GetComponent<Rigidbody> ();
		ThisBody.constraints = RigidbodyConstraints.FreezeRotationY;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Transform> ().eulerAngles.x <= 25f) {
			XPosOn = true;
		}else if (this.GetComponent<Transform>().eulerAngles.x >= 335f) {
			XPosOn = true;
		}else if (this.GetComponent<Transform> ().eulerAngles.x > 25f) {
			XPosOn = false;
		} else if (this.GetComponent<Transform> ().eulerAngles.x < -25f) {
			XPosOn = false;
		}

		if (this.GetComponent<Transform> ().eulerAngles.z <= 25f) {
			ZPosOn = true;
		}else if (this.GetComponent<Transform>().eulerAngles.z >= 335f) {
			ZPosOn = true;
		}else if (this.GetComponent<Transform> ().eulerAngles.z > 25f) {
			ZPosOn = false;
		} else if (this.GetComponent<Transform> ().eulerAngles.z < -25f) {
			ZPosOn = false;
		}

		if (XPosOn == true && ZPosOn == true) {
			ThisBody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		} else if (XPosOn == true && ZPosOn == false) {
			ThisBody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
		} else if (XPosOn == false && ZPosOn == true) {
			ThisBody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX;
		} else if (XPosOn == false && ZPosOn == false) {
			ThisBody.constraints = RigidbodyConstraints.FreezeRotationY;
		}
	}

}
