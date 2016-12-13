using UnityEngine;
using System.Collections;

public class WhellControler : MonoBehaviour {
	float torque = 50f;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		rb.maxAngularVelocity = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		rb.AddRelativeTorque(20, 0, 0);
	}
}
