using UnityEngine;
using System.Collections;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class station : MonoBehaviour {
	public string nextStation;	//次の駅
	public string[] trainType ;	//列車種別
	public bool[] isPassTrainType;	//通過種別のトグル　通過の場合はcheck
	public float stopTime;	//最短停車時間
	public float timeRequired;	//次の駅への所要時間

	private DateTime departureTime;	//発車時間

	private bool bPass;	//通過するか
	private bool bTrainStop;	//停車したか
	private bool bStationStop;	//一度駅に停車したか

	private GameObject Canvas;

	private Collider train;

	// Use this for initialization
	void Start () {
		bTrainStop = false;
		bStationStop = false;
		Canvas = GameObject.Find("Canvas");
		train = null;
	}
	
	// Update is called once per frame
	void Update () {
		if(departureTime < DateTime.Now && bTrainStop && !bStationStop) {
			Debug.Log("test");
			bStationStop = true;
			train.GetComponent<TrainController>().bTrainStop = false;
		}
	
	}

	void OnTriggerStay(Collider collider) {
		if (ArrayUtility.Contains( trainType ,collider.GetComponent<TrainController> ().trainType) && isPassTrainType[ArrayUtility.IndexOf(trainType ,collider.GetComponent<TrainController> ().trainType) ] ){
			bPass = true;
		}

		if( collider.GetComponent<TrainController>().trainSpeed == 0 && !bTrainStop) {
			bTrainStop = true;
			collider.GetComponent<TrainController>().bTrainStop = true;
			train = collider;
			stop();
			//if (departureTime == null) departureTime = ;
		}
		//Debug.Log(bTrainStop);
	}

	void OnTriggerExit(Collider collider) {
		bTrainStop = false;
		bStationStop = false;
		train = null;
	}

	//列車が停車したときの処理
	void stop() {
		departureTime = DateTime.Now + new TimeSpan(0, 0, (int)stopTime);
		Debug.Log(departureTime);
	}
}
