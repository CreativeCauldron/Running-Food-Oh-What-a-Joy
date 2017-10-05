using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour {

	public float MaxX;
	public float MinX;
	public float MaxZ;
	public float MinZ;
	public float XVel;
	public float ZVel;

	public Vector3 Destination;
	public Vector3 Distance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Distance = GetComponent<Transform> ().position - Destination;
	
		if (Distance.magnitude > 0.001f) {
			if (Distance.x > 0.001f) {
				XVel = -5f;
			} else if (Distance.x < 0.001f) {
				XVel = 5f;
			} else {
				XVel = 0f;
			}

			if (Distance.z > 0.001f) {
				ZVel = -5f;
			} else if (Distance.z < 0.001f) {
				ZVel = 5f;
			} else {
				ZVel = 0f;
			}
			transform.Translate (ZVel * Time.deltaTime,0f, ZVel * Time.deltaTime);

		} else if (Distance.magnitude >= 0.001f && Distance.magnitude <= 0.001f) {
			Destination = new Vector3 (Random.Range (MinX, MaxX), GetComponent<Transform> ().position.y, Random.Range (MinZ, MaxZ));
		}
	}
}
