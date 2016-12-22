using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class station : MonoBehaviour {
	public string nextStation;	//次の駅
	public string[] trainType ;	//列車種別
	public bool[] isPassTrainType;	//通過種別のトグル　通過の場合はcheck
	public float stopTime;	//停車時間


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider collider) {
		Debug.Log(collider);
	}
}
