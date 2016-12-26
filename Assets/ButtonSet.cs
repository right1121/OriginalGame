using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSet : MonoBehaviour {
	//現在選択中のボタン
	private GameObject SelectionButton;
	//背景色
	private Color32 imgColor;

	//シーン移り変わり判定
	private bool sceneCheck = false;
	//次のシーン
	public string nextSceneStr;
	//前のシーン
	public string backSceneStr;


	//路線名
	public static string routeName = "";
	public static string getRouteName() {
		return routeName;
	}

	//列車名
	public static string trainName = "";
	public static string getTrainName() {
		return trainName;
	}

	//種別
	public static string trainType = "";
	public static string getTrainType() {
			return trainType;
	}

	// Use this for initialization
	void Start () {
		//非選択時の背景
		imgColor = new Color32(92, 92, 92, 255);

		//初期化
		SelectionButton = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void selectionButton(GameObject obj) {

		//前回選択されたボタンを非選択の色に
		if (SelectionButton != null && SelectionButton != obj) {
			SelectionButton.GetComponent<Image>().color = imgColor;
		}

		//ルートセレクトなら路線名を取得
		if(SceneManager.GetActiveScene().name == "RouteSelect") {
			routeName = obj.name;


		}else if(SceneManager.GetActiveScene().name == "") {

		}else {
			//列車種別を設定
			trainType = obj.transform.Find("TypeImage/Type").GetComponent<Text>().text;
		}



		//選択ボタンのオブジェクトを更新
		SelectionButton = obj;

		sceneCheck = true;

	}

	public void nextScene() {
		if(sceneCheck) {

			SceneManager.LoadScene(nextSceneStr);
		}
	}
	public void backScene() {
		if(backSceneStr != "") {
			SceneManager.LoadScene(backSceneStr);
		}
	}
}
