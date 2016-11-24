using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBackChange : MonoBehaviour {
	private Image img;

	//クリックされたときの処理
	public void ClickTest() {
		//imageコンポーネントの取得
		img = GetComponent<Image>();

		//色の変更
		img.color = new Color32(178, 178, 178, 255);

		GameObject.Find("ButtonSelect").GetComponent<ButtonSet> ().selectionButton(gameObject);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
