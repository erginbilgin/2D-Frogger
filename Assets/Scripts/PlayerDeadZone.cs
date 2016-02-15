using UnityEngine;
using System.Collections;

public class PlayerDeadZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
        // Frog?
        if (coll.name == "Frog")
        	Destroy(coll.gameObject);
    }
}
