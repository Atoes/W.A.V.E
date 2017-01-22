using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Reset : MonoBehaviour {
    public float GameTimer = 99;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameTimer -= Time.deltaTime;
        if ((Input.GetAxis("Reset") != 0) || (GameTimer <= 0)){
            SceneManager.LoadScene("wave");
        }
	}
}
