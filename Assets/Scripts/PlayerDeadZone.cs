using UnityEngine;
using System.Collections;

public class PlayerDeadZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
        // Frog?
        if (coll.name == "Frog")
        	Destroy(coll.gameObject);
    }
}
