using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Key : MonoBehaviour
{
    private bool cooldown;
    private float timer;
    public GameObject bullet;
    private Rigidbody rb;
    private Vector3 input;
    private Vector3 rotateX;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cooldown = true;
        timer = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //timer code
        timer -= Time.deltaTime;
        //Debug.Log (GameTimer);
        if (timer < 0)
        {
            cooldown = true;
        }
        var z = Input.GetAxis("Vertical") * Time.fixedDeltaTime * 30.0f;
        rotateX = new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f);
        rotateX *= 300f * Time.deltaTime;

        Quaternion deltaRotation = Quaternion.Euler(rotateX);
        //transform.position -= transform.forward * z;
        //transform.Rotate(0, rotateX, 0);
        rb.velocity = transform.forward * z;//input * Time.deltaTime * 1000.0f;
        rb.MoveRotation(rb.rotation * deltaRotation);
        Debug.Log(z);
    }
}
