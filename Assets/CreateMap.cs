using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour {
	//レール
	public GameObject RailPrefab;
	//レール位置・角度
	private Transform railPos = null;
	//レールの間隔
	private float railInterval = 0.6f;

	//円の中心
	private Vector3 circlePos = Vector3.zero;

	//各座標
	private float x=0, y=0, z=0;

	//回転角
	private float roundX = 0, roundY = 0, roundZ = 0;
	
	//曲線半径
	private float r = 0;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 1000; i++) {

			//座標
			transform.Translate(x, y, railInterval);

			//カーブ区間
				if (i > 100 && i < 200){
					r = 100;
				}else if (i > 220 && i < 400) {
					r = -100;
				} else { 
					r = 0;
				}

					if (r != 0) {
						roundY = 360 * railInterval / (2 * Mathf.PI * r);
						Debug.Log(roundY);
					}else {
						roundY = 0;
					}
				//回転
				transform.Rotate(roundX, roundY, roundZ);

			//Prefabの配置
			GameObject Rail = Instantiate (RailPrefab) as GameObject;
			Rail.transform.position = transform.position;
			Rail.transform.eulerAngles = transform.eulerAngles;
			
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
