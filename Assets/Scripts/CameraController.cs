using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float cameraSpeed = 1;

	public void Start(){
		//gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, cameraSpeed);
			
	}
	public void FixedUpdate(){
		Vector3 movement = new Vector3(0.0f, 0.5f, 0.0f) * Time.deltaTime;
 		transform.Translate(movement);
	}
}
