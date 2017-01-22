using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveLength : MonoBehaviour {

    private float MoveSpeed = 10.0f;

    private float frequency = 15.0f;  // Speed of sine movement
    private float magnitude = 1.0f;   // Size of sine movement
    private Vector3 axis;
    private Vector3 playervec3;
    private Vector3 pos;
    private bool reflect;
    private float timer;

    private PlayerControl script;

    private GameObject player;
    //Vector3 plsWork = new Vector3 (-2f, 0f, 0f);
    public AudioClip[] audioClip;
    void PlayAudio(int clip)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClip[clip];
        audio.Play();

    }
    void Start()
    {
        reflect = false;
        player = GameObject.Find("GameObject");

        pos = transform.position;
        DestroyObject(gameObject, 5.0f);
        transform.forward = player.transform.forward;
        axis = transform.up;
        transform.up = player.transform.forward;

        script = player.GetComponent<PlayerControl>();
        timer = script.GameTimer;
    }

    void OnCollisionEnter(Collision collision)
    {
        //print("Detected between " + gameObject.name + " and " + collision.collider.name);
        if (collision.collider.name == "wall_Long" || collision.collider.name == "wall_Small" || collision.collider.name == "wall_Small(1)" || collision.collider.name == "wall_Long(1)")
        {
            PlayAudio(0);
            foreach (ContactPoint contact in collision.contacts)
            {
                transform.up = 2 * (Vector3.Dot(transform.up, Vector3.Normalize(contact.normal))) * Vector3.Normalize(contact.normal) - transform.up;
                transform.up *= -1;
            }
            GameObject wall = GameObject.Find(collision.collider.name);
            Color myColor = new Color32(0xFF, 0x00, 0x4F, 0xFF);
            wall.GetComponent<Renderer>().material.color = myColor;
        }
        if ((collision.collider.name == "Player") || (collision.collider.name == "Player2"))
        {
            PlayAudio(1);
        }
        if (collision.collider.name == "Floor")
        {
            //Debug.Log("I am colliding with floor");
            Vector3 temp = transform.position;
            temp.y = 1.5f;

            transform.position = temp;
        }
    }

    void Update()
    {
        //MoveSpeed += .01f;
        float fMoveSpeed = MoveSpeed + ((99 - timer) / 10) * 1f;
        float ffrequency = frequency + ((99 - timer) / 10) * .8f;
        float fmagnitude = magnitude + ((99 - timer) / 10) * .05f;
        //pos -= player.transform.forward * Time.deltaTime * MoveSpeed;
        //transform.position = (pos + axis * (Mathf.Sin(Time.time * (frequency / 2f)) * (magnitude - .5f))) + transform.forward * 2f;
        pos += transform.up * Time.deltaTime * fMoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * ffrequency) * fmagnitude;
        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;

    }
}
