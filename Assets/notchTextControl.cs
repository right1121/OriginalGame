using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class notchTextControl : MonoBehaviour {
	private Slider notch;
	private Text notchText;

	// Use this for initialization
	void Start () {
		notch = GameObject.Find("masterController").GetComponent<Slider>();
		notchText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		notch = GameObject.Find("masterController").GetComponent<Slider>();

		if	(notch.value == 0)	notchText.text = "N";

		if	(notch.value < 0)	notchText.text = "P" + Mathf.Abs( notch.value );

		if	(notch.value > 0)	notchText.text = "B" + Mathf.Abs( notch.value );

		if	(notch.value == notch.maxValue)	notchText.text = "EB";
	}
}
