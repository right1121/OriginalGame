using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrainController : MonoBehaviour {


	private Slider notch;	//電車のノッチ
	private int maxnotch = 8;	//ノッチの上限(ブレーキの上限)
	private int minnotch = -4;	//ノッチの下限(加速の上限)

	public string trainType;	//列車種別
	public string trainNumber;	//列車番号

	public float trainSpeed;	//速度

	private float speedLimit;	//最高速度

	//ホイール
	private Rigidbody[] wheel;		//すべてのホイールのRigidbody
	public GameObject speedWheel;	//列車速度取得用ホイール
	private Rigidbody speedWheelRb;	//速度用ホイールのRigidbody

	public bool bTrainStop;	//駅に停車しているか。発車時間になるまで力行不可

	// Use this for initialization
	void Start () {

		this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -2, 0);	//重心

		//ホイールの検索
		if (wheel == null) {
			wheel = GetComponentsInChildren<Rigidbody>();
			foreach(Rigidbody rb in wheel) {
				rb.maxAngularVelocity = 50;
			}

		bTrainStop = false;
		}

		//列車番号の取得
		trainNumber = ButtonSet.getTrainName();

		//列車種別の取得
		trainType = ButtonSet.getTrainType();

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

		//完全に停止
		if(notch.value > 0 && speedWheelRb.angularVelocity.x < 0.1) {
			foreach(Rigidbody rb in wheel) {
				rb.angularVelocity = Vector3.zero;
				rb.velocity = Vector3.zero;
				rb.AddTorque(0, 0, 0);
		}
		} else{
		//減速
		if (notch.value == 7) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(-40, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == 6) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(-35, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == 5) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(-30, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == 4) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(-25, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == 3) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(-20, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == 2) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(-15, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == 1) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(-10, 0, 0);
			}
			//Debug.Log(notch.value);
		}
		}

		//蛇行
		if (notch.value == 0) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(0, 0, 0);
			}
			//Debug.Log(notch.value);
		}

		//加速
		if (notch.value == -1 && !bTrainStop) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(10, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == -2 && !bTrainStop) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(20, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == -3 && !bTrainStop) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(30, 0, 0);
			}
			//Debug.Log(notch.value);
		}else if (notch.value == -4 && !bTrainStop) {
			foreach(Rigidbody rb in wheel) {
				rb.AddRelativeTorque(50, 0, 0);
			}
			//Debug.Log(notch.value);
		}
		
	}

}
