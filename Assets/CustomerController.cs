using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour {

	public Vector3 Location1;
	public Vector3 Location2;
	public Vector3 Destination;
	public Vector3 Distance;

	public bool AtLocation = false;
	public bool DestinationIs1 = true;
	public bool DestinationIs2 = false;

	// Use this for initialization
	void Start () {
		Destination = Location1;
	}
	
	// Update is called once per frame
	void Update () {
		if (AtLocation == false) {
			Distance = GetComponent<Transform> ().position - Destination;
			if (Distance.magnitude > 0.1f) {
				if (Distance.x > .001f && Distance.z > 0.001f) {
					this.transform.Translate (-2f * Time.deltaTime, 0f, -2f * Time.deltaTime);
				} else if (Distance.x <= 0.001f && Distance.z > 0.001f) {
					this.transform.Translate (2f * Time.deltaTime, 0f, -2f * Time.deltaTime);
				} else if (Distance.x > .001f && Distance.z <= 0.001f) {
					this.transform.Translate (-2f * Time.deltaTime, 0f, 2f * Time.deltaTime);
				} else if (Distance.x <= 0.001f && Distance.z <= 0.001f) {
					this.transform.Translate (2f * Time.deltaTime, 0f, 2f * Time.deltaTime);
				}
			} else if (Distance.magnitude <= .1f) {
				AtLocation = true;
			}
		} else if (AtLocation == true) {
			if (DestinationIs1 == true && DestinationIs2 ==false) {
				Destination = Location2;
				DestinationIs1=false;
				DestinationIs2 = true;
			} else if (DestinationIs2 == true && DestinationIs1==false) {
				Destination = Location1;
				DestinationIs1=true;
				DestinationIs2 = false;
			}
			AtLocation = false;
		}
	}
}
