using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float cameraSpeed = 1;

	public void Start(){
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, cameraSpeed);	

	}

	private void Update(){

	}


}
