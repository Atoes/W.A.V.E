using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {

	private GameObject canvas;

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Start") != 0) {
			//Application.LoadLevel("wave");
			Debug.Log("dflakjd");
			Destroy(canvas);

		}
	}
}
