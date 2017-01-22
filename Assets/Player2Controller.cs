using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {
    public GameObject bullet2;
    private Rigidbody rb;
    private Vector3 input;
    private Vector3 rotateX;
    // Use this for initialization
    private bool cooldown;
    private float timer;
    public float GameTimer = 99;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cooldown = true;
        timer = -1;
    }

    public AudioClip[] audioClip;

    void PlayAudio(int clip)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClip[clip];
        audio.Play();

    }
    // Update is called once per frame
    void FixedUpdate () {
        //var x = Input.GetAxis("Horizontal2") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical2") * Time.deltaTime * 3.0f;
        //timer code
        timer -= Time.deltaTime;
        GameTimer -= Time.deltaTime;
        //Debug.Log (GameTimer);
        if (timer < 0)
        {
            cooldown = true;
        }
        if (Input.GetAxis("X2") != 0 && cooldown)
        {
            Instantiate(bullet2, transform.position + (transform.forward * 2), Quaternion.identity);
            cooldown = false;
            PlayAudio(0);
            timer = 1.5f;
        }

        var z = Input.GetAxis("LeftStickV2") * Time.fixedDeltaTime * 3000.0f;
        //var x = Input.GetAxis("LeftStickH") * Time.deltaTime * 30.0f;

        input = new Vector3(0.0f, 0.0f, Input.GetAxis("LeftStickV2"));
        rotateX = new Vector3(0.0f, Input.GetAxis("RightStickH2"), 0.0f);
        rotateX *= 2700f * Time.deltaTime * -1;

        Quaternion deltaRotation = Quaternion.Euler(rotateX);
        //transform.position -= transform.forward * z;
        //transform.Rotate(0, rotateX, 0);
        rb.velocity = -1 * transform.forward * z;//input * Time.deltaTime * 1000.0f;
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
