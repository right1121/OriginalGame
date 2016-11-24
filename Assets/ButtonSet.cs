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


	//路線名　ボタンの名前を路線名にする
	public static string routeName = "";
	public static string getRouteName() {
		return routeName;
	}

	//列車名　ボタンの名前を列車名にする
	public static string trainName = "";
	public static string getTrainName() {
		return trainName;
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
			trainName = obj.name;
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
