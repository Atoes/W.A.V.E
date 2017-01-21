using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveLength : MonoBehaviour {

    public float MoveSpeed = 5.0f;

    public float frequency = 15.0f;  // Speed of sine movement
    public float magnitude = 1.0f;   // Size of sine movement
    private Vector3 axis;
    private Vector3 playervec3;
    private Vector3 pos;

    private GameObject player;
    //Vector3 plsWork = new Vector3 (-2f, 0f, 0f);

    void Start()
    {

        player = GameObject.Find("GameObject");

        pos = transform.position;
        DestroyObject(gameObject, 5.0f);
        axis = player.transform.forward;

    }

    void Update()
    {
        //MoveSpeed += .01f;

        //pos -= player.transform.forward * Time.deltaTime * MoveSpeed;
        //transform.position = (pos + axis * (Mathf.Sin(Time.time * (frequency / 2f)) * (magnitude - .5f))) + transform.forward * 2f;

        transform.position += axis * MoveSpeed * Time.deltaTime;

    }
}
