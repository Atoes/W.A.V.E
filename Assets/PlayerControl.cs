using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public GameObject bullet;
    private Rigidbody rb;
    private Vector3 input;
    private Vector3 rotateX;
    // Use this for initialization
	private bool cooldown;
	private float timer;
	public float GameTimer = 99;

    public AudioClip[] audioClip;

    void Start () {
        rb = GetComponent<Rigidbody>();
		cooldown = true;
		timer = -1;
	}
	

    void PlayAudio(int clip)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClip[clip];
        Debug.Log(audioClip[0]);
        audio.Play();

    } 
	// Update is called once per frame
	void FixedUpdate () {
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //if (Input.GetAxis("X") != 0) {

		//timer code
		timer -= Time.deltaTime;
		GameTimer -= Time.deltaTime;
        if (GameTimer <= 0)
        {
            SceneManager.LoadScene("wave");
        }
        //Debug.Log (GameTimer);
        if (timer < 0){
			cooldown = true;
		}

        if (Input.GetAxis("X") != 0 && cooldown) { 
            Instantiate(bullet, transform.position + (transform.forward * 2), Quaternion.identity);
			cooldown = false;
            PlayAudio(0);
			timer = 1.5f;
        }
        var z = Input.GetAxis("LeftStickV") * Time.fixedDeltaTime * 3000.0f;
        //var x = Input.GetAxis("LeftStickH") * Time.deltaTime * 30.0f;

        input = new Vector3(0.0f, 0.0f, Input.GetAxis("LeftStickV"));

            rotateX = new Vector3(0.0f, Input.GetAxis("RightStickH"), 0.0f);
            rotateX *= 2700f * Time.deltaTime;


        Quaternion deltaRotation = Quaternion.Euler(rotateX);
        //transform.position -= transform.forward * z;
        //transform.Rotate(0, rotateX, 0);
        rb.velocity = -1*transform.forward * z;//input * Time.deltaTime * 1000.0f;
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

}
