using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrainController : MonoBehaviour {


	private Slider notch;	//電車のノッチ
	private int maxnotch = 8;	//ノッチの上限(ブレーキの上限)
	private int minnotch = -4;	//ノッチの下限(加速の上限)

	private string TrainType;	//列車種別
	private int TrainNumber;	//列車番号

	private float trainSpeed;	//速度

	private float speedLimit;	//最高速度

	//ホイール
	private Rigidbody[] wheel;		//すべてのホイールのRigidbody
	public GameObject speedWheel;	//列車速度取得用ホイール
	private Rigidbody speedWheelRb;	//速度用ホイールのRigidbody

	// Use this for initialization
	void Start () {

		this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -2, 0);	//重心

		//ホイールの検索
		if (wheel == null) {
			wheel = GetComponentsInChildren<Rigidbody>();
			foreach(Rigidbody rb in wheel) {
				rb.maxAngularVelocity = 50;
			}
		}

		notch = GameObject.Find("masterController").GetComponent<Slider>();

		speedWheelRb = speedWheel.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		//スピード
		GameObject.Find("speed").GetComponent<Text>().text = trainSpeed.ToString();

		//ノッチ数の取得
		notch = GameObject.Find("masterController").GetComponent<Slider>();

		

	}

	void FixedUpdate() {
		//速度の計算

		trainSpeed = Mathf.Round( speedWheelRb.angularVelocity.x * 2);

		foreach(Rigidbody rb in wheel) {
			if(trainSpeed > 0)	rb.AddForce(0, -2 * trainSpeed, 0);
			}

		//減速
		if (notch.value == 2) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(-20, 0, 0);
			}
			//Debug.Log(notch.value);
		}
		if (notch.value == 1) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(-10, 0, 0);
			}
			//Debug.Log(notch.value);
		}

		//蛇行
		if (notch.value == 0) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(0, 0, 0);
			}
			//Debug.Log(notch.value);
		}

		//加速
		if (notch.value == -1) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(10, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == -2) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(30, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == -3) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(80, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == -4) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(100, 0, 0);
			}
			//Debug.Log(notch.value);
		}

		
		//完全に停止
		if(notch.value > 0 && speedWheelRb.angularVelocity.x < 0.01) {
			foreach(Rigidbody rb in wheel) {
				rb.angularVelocity = Vector3.zero;
			}
		}
	}

}
