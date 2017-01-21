using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveLength2 : MonoBehaviour {

    public int speed = 6;
    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    private Vector3 v;
    public Rigidbody rb;
    GameObject player;

    // Use this for initialization
    void Start()
    {

        // Get the rigidbody component
        rb = GetComponent<Rigidbody>();

        player = GameObject.Find("GameObject(1)");
        var playervec3 = player.transform.forward;

        // Make the bullet move upward

        v = playervec3;

        //pos	= transform.position;
    }
    void Update()
    {
        //MoveSpeed += .01f;

        //pos -= player.transform.forward * Time.deltaTime * MoveSpeed;
        //transform.position = (pos + axis * (Mathf.Sin(Time.time * (frequency / 2f)) * (magnitude - .5f))) + transform.forward * 2f;

        transform.position += player.transform.forward * speed * Time.deltaTime;

    }
    // Update is called once per frame
    /*void FixedUpdate () {
    rb.AddForce(10.0f * player.transform.forward);
    }*/

}
