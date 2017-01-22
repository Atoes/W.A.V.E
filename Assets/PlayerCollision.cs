using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    void OnCollisionEnter(Collision coll){
        if ((coll.gameObject.name == "bullet(Clone)") || (coll.gameObject.name == "bullet2(Clone)")) {
            Destroy(gameObject);
        }
    }
}
