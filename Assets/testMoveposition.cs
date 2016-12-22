using UnityEngine;
using System.Collections;

public class testMoveposition : MonoBehaviour {
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		rb.MovePosition(transform.position + transform.forward * 1);
	}
}
