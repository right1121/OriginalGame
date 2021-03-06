﻿using UnityEngine;
using UnityEditor;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshFilter))]

public class CreateMap : MonoBehaviour {
	//レール
	public GameObject RailPrefab;
	//レール位置・角度
	private Transform railPos = null;
	//レールの間隔
	public float railInterval = 0.6f;

	//円の中心
	private Vector3 circlePos = Vector3.zero;

	//各座標
	private float x=0, y=0, z=0;

	//回転角
	private float roundX = 0, roundY = 0, roundZ = 0;
	
	//曲線半径
	public float curve = 0;

	//距離
	public float distance;

	public GameObject gide;

	// Use this for initialization
	void Start () {

		
		GameObject emptyGameObject = new GameObject("rail_r" + curve + "_" + distance * railInterval + "m");

			

		for (int i = 0; i < distance; i++) {

			//座標
			this.transform.Translate(x, y, railInterval);

			//カーブの処理
			if (curve != 0) {
				roundY = 360 * railInterval / (2 * Mathf.PI * curve);
			}else {
				roundY = 0;
			}

			//回転
			transform.Rotate(roundX, roundY, roundZ);

			//Prefabの配置
			GameObject Rail = Instantiate (RailPrefab) as GameObject;
			Rail.transform.position = transform.position;
			Rail.transform.eulerAngles = transform.eulerAngles;
			Rail.name = i.ToString();

			//Prefabをrailと親子関係にする
			Rail.transform.parent = emptyGameObject.transform;


		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
