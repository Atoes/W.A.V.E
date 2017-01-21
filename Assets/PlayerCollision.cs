using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    void OnCollisionEnter(Collision coll){
        if ((coll.gameObject.name == "wall_Small") || (coll.gameObject.name == "wall_Small(1)") || 
            (coll.gameObject.name == "wall_Long") || (coll.gameObject.name == "wall_Long(1)")) {
            Destroy(gameObject);
        }
    }
}
