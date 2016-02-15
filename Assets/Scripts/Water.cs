using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D coll) {
        // Frog?
        if (coll.name == "Frog")
            // Not Jumping?
            if (!coll.GetComponent<FrogController>().isJumping)
                // Not on a platform?
                if (coll.transform.parent == null)
                    // HANDLE GAME OVER HERE
                    Destroy(coll.gameObject);
    }

}
