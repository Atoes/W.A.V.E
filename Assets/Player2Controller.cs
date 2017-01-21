using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {
    public GameObject bullet2;
    private Rigidbody rb;
    private Vector3 input;
    private Vector3 rotateX;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        //var x = Input.GetAxis("Horizontal2") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical2") * Time.deltaTime * 3.0f;
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet2, transform.position + (transform.forward * 2), Quaternion.identity);
        }

        var z = Input.GetAxis("LeftStickV2") * Time.fixedDeltaTime * 1500.0f;
        //var x = Input.GetAxis("LeftStickH") * Time.deltaTime * 30.0f;

        input = new Vector3(0.0f, 0.0f, Input.GetAxis("LeftStickV2"));
        rotateX = new Vector3(0.0f, Input.GetAxis("RightStickH2"), 0.0f);
        rotateX *= 1500f * Time.deltaTime * -1;

        Quaternion deltaRotation = Quaternion.Euler(rotateX);
        //transform.position -= transform.forward * z;
        //transform.Rotate(0, rotateX, 0);
        rb.velocity = -1 * transform.forward * z;//input * Time.deltaTime * 1000.0f;
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
