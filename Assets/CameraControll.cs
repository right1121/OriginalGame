using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {
	public Transform target;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = new Vector3(0, 0, 10);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform>().position = target.position + offset;
	}
}
