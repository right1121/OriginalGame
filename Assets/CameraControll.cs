using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {
	public Transform target;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = new Vector3(-0.5f , 1.2f , 10f);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform>().position = target.position + offset;
		GetComponent<Transform>().rotation = target.rotation;
	}
}
