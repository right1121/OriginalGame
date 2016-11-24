using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class nowTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = "現在時刻　" + System.DateTime.Now.ToString("HH:mm:ss");
	
	}
}
