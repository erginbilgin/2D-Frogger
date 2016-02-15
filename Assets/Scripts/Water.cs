using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

	void OnTriggerStay2D(Collider2D coll) {
        // Frog?
        if (coll.tag == "Player")
            // Not Jumping?
			if (!coll.GetComponent<FrogController>().isJumping)
                // Not on a platform?
                if (coll.transform.parent == null)
                    // HANDLE GAME OVER HERE
                    Destroy(coll.gameObject);
    }

}
