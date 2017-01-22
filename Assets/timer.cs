using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{

    private float gtimer = 99f;
    GameObject timertext;

    // Use this for initialization
    void Start()
    {
        timertext = GameObject.Find("Timer");
        timertext.GetComponent<TextMesh>().text = ("" + gtimer).Substring(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        gtimer -= Time.deltaTime;

        timertext = GameObject.Find("Timer");
        timertext.GetComponent<TextMesh>().text = ("" + gtimer).Substring(0, 5);

    }
}