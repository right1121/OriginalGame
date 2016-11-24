using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MakeTrainButton : MonoBehaviour {
	//ボタンのプレハブ
	public GameObject trainButtonPrefab;

	private GameObject obj;
	private GameObject buttonPos;

	//時間
	private DateTime trainTime;

	//繰り返し
	private bool check = true;
	private int i = 0;

	//使用する行先一覧
	private string[] useDestination;
	//行先一覧
	public string[] destination_1;
	public string[] destination_2;
	public string[] destination_3;

	//種別一覧
	public string[] trainType;


	// Use this for initialization
	void Start () {

		//trainTimeの初期化
		trainTime = new DateTime(2000, 1, 1, DateTime.Now.Hour , 0, 0);

		//親オブジェクトの検索
		buttonPos = GameObject.Find("Content");


		while(check) {
			//プレハブを使用してオブジェクトの作成
			obj = (GameObject)Instantiate (trainButtonPrefab);
			//プレハブをContentの子オブジェクトに移動
			obj.transform.SetParent(buttonPos.transform, false);

			//路線名で駅名を変更
			switch (ButtonSet.getRouteName()) {
				case "1":useDestination = destination_1;
					break;
				case "2":useDestination = destination_2;
					break;
				case "3":useDestination = destination_3;
					break;
				default:
					break;
			}

			//列車ごとに情報を変更
			switch (i){
				case 0: setTrainDate(obj, "普通", new Color32(255,255,255,255), useDestination[i], trainTime.ToString("HH:mm") , 6 , "101");
					break;
				case 1: trainTime = trainTime.AddMinutes(15);
						setTrainDate(obj, "普通", new Color32(255,255,255,255), "南浦和", trainTime.ToString("HH:mm") , 6 , "103");
					break;
				case 2: trainTime = trainTime.AddMinutes(15);
						setTrainDate(obj, "普通", new Color32(255,255,255,255), "蒲田", trainTime.ToString("HH:mm") , 6 , "105");
					break;
				case 3: trainTime = trainTime.AddMinutes(15);
						setTrainDate(obj, "普通", new Color32(255,255,255,255), "桜木町", trainTime.ToString("HH:mm") , 6 , "107");
					break;
			default:
				check = false;
				Destroy (obj);
				break;
			}
			i++;
			continue;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//オブジェクト　ラインカラー　路線名　路線特徴　路線詳細
	void setTrainDate (GameObject obj,string trainType,  Color32 lineColor, string destination, string time, int cars, string trainNunber) {
		obj.transform.FindChild("TypeImage").FindChild("Type").GetComponent<Text>().text = trainType;					//種別
		obj.transform.FindChild("TypeImage").GetComponent<Image>().color = lineColor;			//色
		obj.transform.FindChild("Destination").GetComponent<Text>().text = destination;			//行先
		obj.transform.FindChild("Time").GetComponent<Text>().text = time;						//時間
		obj.transform.FindChild("Cars").GetComponent<Text>().text = cars.ToString() + "両";		//両数
		obj.name = trainNunber;		//オブジェクトの名前変更
	}

	void setStationParameter(string routeName) {
		switch(routeName) {
			case "1":
				
				break;

			case "2":

				break;

			case "3":

				break;

		}
	}
}
