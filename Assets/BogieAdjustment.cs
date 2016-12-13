using UnityEngine;
using System.Collections;

public class BogieAdjustment : MonoBehaviour {
	//力を与える向き
	private int direction;

	private Vector3 curveRotation;

	private Rigidbody obj;

	// Use this for initialization
	void Start () {
		direction = (this.name == "rightTriger") ? -1 : 1;
		Debug.Log(direction);
		curveRotation = new Vector3(0, direction, 0);

		obj = GameObject.Find("bogie").GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTrigerStay(Collider other) {
			obj.angularVelocity = curveRotation;
			Debug.Log("a");
	}

}
