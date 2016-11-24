using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrainController : MonoBehaviour {

	//電車のノッチ
	private Slider notch;
	//ノッチの上限(ブレーキの上限)
	private int maxnotch = 8;
	//ノッチの下限(加速の上限)
	private int minnotch = -4;

	//速度
	private float trainSpeed;

	//最高速度
	private float speedLimit;


	//車輪
	public WheelCollider LF;
	public WheelCollider RF;
	public WheelCollider LR;
	public WheelCollider RR;

	


	// Use this for initialization
	void Start () {
		//重心
		this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -2, 0);
		
	}
	
	// Update is called once per frame
	void Update () {

		//スピード
		trainSpeed = LF.rpm * 60;
		GameObject.Find("speed").GetComponent<Text>().text = trainSpeed.ToString();

		//ノッチ数の取得
		notch = GameObject.Find("masterController").GetComponent<Slider>();

		
		//減速
		if (notch.value == 1) {
			LF.brakeTorque = 600;
			RF.brakeTorque = 600;
			LR.brakeTorque = 600;
			RR.brakeTorque = 600;
			//Debug.Log(notch.value);
		}

		//蛇行
		if (notch.value == 0) {
			LF.motorTorque = 0;
			RF.motorTorque = 0;
			LR.motorTorque = 0;
			RR.motorTorque = 0;
			LF.brakeTorque = 0;
			RF.brakeTorque = 0;
			LR.brakeTorque = 0;
			RR.brakeTorque = 0;
			//Debug.Log(notch.value);
		}

		//加速
		if (notch.value == -1) {
			//GetComponent<Rigidbody>().AddForce(transform.forward * 100000);
		}else if (notch.value == -2) {
			LF.motorTorque = 600;
			RF.motorTorque = 600;
			LR.motorTorque = 600;
			RR.motorTorque = 600;
			//Debug.Log(notch.value);
		}else if (notch.value == -3) {
			LF.motorTorque = 1000;
			RF.motorTorque = 1000;
			LR.motorTorque = 1000;
			RR.motorTorque = 1000;
			//Debug.Log(notch.value);
		}else if (notch.value == -4) {
			LF.motorTorque = 3000;
			RF.motorTorque = 3000;
			LR.motorTorque = 3000;
			RR.motorTorque = 3000;
			//Debug.Log(notch.value);
		}

		//傾きの制御
		

	}
}
