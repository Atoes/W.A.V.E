using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public AudioClip[] audioClip1;

    void PlayAudio(int clip)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClip1[clip];
        audio.Play();

    }
    void OnCollisionEnter(Collision coll){
        if ((coll.gameObject.name == "bullet(Clone)") || (coll.gameObject.name == "bullet2(Clone)")) {
            Destroy(gameObject);
        }
    }
}
