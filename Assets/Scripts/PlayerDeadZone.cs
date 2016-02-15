using UnityEngine;
using System.Collections;

public class PlayerDeadZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
        // Frog?
        if (coll.tag == "Player")
        	Destroy(coll.gameObject);
    }
}
