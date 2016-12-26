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

		//路線名で設定を変更
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

		setStationParameter(ButtonSet.getRouteName()) ;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//ボタンの項目設定
	//オブジェクト　ラインカラー　路線名　路線特徴　路線詳細
	void setTrainDate (string trainType,  Color32 lineColor, string destination, string time, int cars, string trainNunber) {


		//プレハブを使用してオブジェクトの作成
		obj = (GameObject)Instantiate (trainButtonPrefab);
		//プレハブをContentの子オブジェクトに移動
		obj.transform.SetParent(buttonPos.transform, false);


		obj.transform.FindChild("TypeImage").FindChild("Type").GetComponent<Text>().text = trainType;					//種別
		obj.transform.FindChild("TypeImage").GetComponent<Image>().color = lineColor;			//色
		obj.transform.FindChild("Destination").GetComponent<Text>().text = destination;			//行先
		obj.transform.FindChild("Time").GetComponent<Text>().text = time;						//時間
		obj.transform.FindChild("Cars").GetComponent<Text>().text = cars.ToString() + "両";		//両数
		obj.name = trainNunber;		//オブジェクトの名前変更
	}

	//時刻表
	void setStationParameter(string routeName) {
		switch(routeName) {
			case "1":
					setTrainDate(trainType[0], getTrainTypeColor(0) , useDestination[0], trainTime.ToString("HH:mm") , 6 , "101");
					trainTime = trainTime.AddMinutes(15);

					setTrainDate(trainType[0], getTrainTypeColor(0) , useDestination[1], trainTime.ToString("HH:mm") , 6 , "103");
					trainTime = trainTime.AddMinutes(15);

					setTrainDate(trainType[0], getTrainTypeColor(0) , useDestination[2], trainTime.ToString("HH:mm") , 6 , "105");
					trainTime = trainTime.AddMinutes(15);

					setTrainDate(trainType[0], getTrainTypeColor(0) , useDestination[3], trainTime.ToString("HH:mm") , 6 , "107");
				break;

			case "2":
					setTrainDate(trainType[6], getTrainTypeColor(6) , useDestination[0], trainTime.ToString("HH:mm") , 10 , "201");
					trainTime = trainTime.AddMinutes(1);

					setTrainDate(trainType[1], getTrainTypeColor(1) , useDestination[0], trainTime.ToString("HH:mm") , 8 , "203");
					trainTime = trainTime.AddMinutes(4);

					setTrainDate(trainType[4], getTrainTypeColor(4) , useDestination[0], trainTime.ToString("HH:mm") , 8 , "205");
					trainTime = trainTime.AddMinutes(3);

					setTrainDate(trainType[1], getTrainTypeColor(1) , useDestination[1], trainTime.ToString("HH:mm") , 8 , "207");
					trainTime = trainTime.AddMinutes(2);
					
					setTrainDate(trainType[1], getTrainTypeColor(1) , useDestination[0], trainTime.ToString("HH:mm") , 8 , "207");

				break;

			case "3":
					trainTime = trainTime.AddMinutes(2);

					setTrainDate(trainType[7], getTrainTypeColor(7) , useDestination[2], trainTime.ToString("HH:mm") , 8 , "301");
					trainTime = trainTime.AddMinutes(5);

					setTrainDate(trainType[2], getTrainTypeColor(2) , useDestination[0], trainTime.ToString("HH:mm") , 12 , "303");
					trainTime = trainTime.AddMinutes(2);

					setTrainDate(trainType[0], getTrainTypeColor(0) , useDestination[3], trainTime.ToString("HH:mm") , 4 , "305");
					trainTime = trainTime.AddMinutes(3);

					setTrainDate(trainType[7], getTrainTypeColor(7) , useDestination[2], trainTime.ToString("HH:mm") , 8 , "307");
					trainTime = trainTime.AddMinutes(2);

					setTrainDate(trainType[0], getTrainTypeColor(0) , useDestination[4], trainTime.ToString("HH:mm") , 4 , "309");
					trainTime = trainTime.AddMinutes(3);

					setTrainDate(trainType[7], getTrainTypeColor(7) , useDestination[0], trainTime.ToString("HH:mm") , 6 , "311");
					trainTime = trainTime.AddMinutes(2);

					setTrainDate(trainType[0], getTrainTypeColor(0) , useDestination[1], trainTime.ToString("HH:mm") , 8 , "313");
					trainTime = trainTime.AddMinutes(3);

					setTrainDate(trainType[7], getTrainTypeColor(7) , useDestination[2], trainTime.ToString("HH:mm") , 6 , "315");
					trainTime = trainTime.AddMinutes(5);

					setTrainDate(trainType[2], getTrainTypeColor(2) , useDestination[0], trainTime.ToString("HH:mm") , 8 , "317");
					trainTime = trainTime.AddMinutes(2);

					setTrainDate(trainType[0], getTrainTypeColor(0) , useDestination[1], trainTime.ToString("HH:mm") , 12 , "319");

				break;

		}
	}

	
	Color32 getTrainTypeColor(int trainType) {	//種別ごとの色設定
		Color32 trainTypeColor = new Color32(255, 255, 255, 255);

		switch(trainType.ToString()) {
			case "0":	
			case "1":	trainTypeColor = new Color32(255, 255, 255, 255);
				break;
			case "2":	trainTypeColor = new Color32(0, 234, 255, 255);
				break;
			case "3":	trainTypeColor = new Color32(0, 152, 0, 255);
				break;
			case "4":	trainTypeColor = new Color32(238, 25, 25, 255);
				break;
			case "5":	trainTypeColor = new Color32(250, 0, 255, 255);
				break;
			case "6":	trainTypeColor = new Color32(255, 142, 0, 255);
				break;
			case "7":	trainTypeColor = new Color32(158, 184, 0, 255);
				break;
			default:	trainTypeColor = new Color32(255, 255, 255, 255);
				break;
		}
		return trainTypeColor;
	}
}
