using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {
	void OnTriggerStay2D(Collider2D coll) {
        // Frog? Then make it a Child
        if (coll.tag == "Player")
            coll.transform.parent = transform;
    }

    void OnTriggerExit2D(Collider2D coll) {
		if (coll.tag == "Player")
        	coll.transform.parent = null;        
    }
}
