using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D coll) {
        // Frog? Then make it a Child
        if (coll.name == "Frog")
            coll.transform.parent = transform;
    }
    
    void OnTriggerExit2D(Collider2D coll) {
    	if (coll.name == "Frog")
        	coll.transform.parent = null;        
    }
}
