using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FrogController))]

public class InputController : MonoBehaviour {
	
	private FrogController frogController;
	public string upButton = "P1_Up";
	public string downButton = "P1_Down";
	public string leftButton = "P1_Left";
	public string rightButton = "P1_Right";

	// Use this for initialization
	void Start () {
		frogController = GetComponent<FrogController>(); 
	}

	// Update is called once per frame
	void Update () {
		if (frogController.playerMovement == null & frogController.IsGameActive())
	    {
			if (Input.GetButtonDown(upButton) & transform.position.y < Camera.main.transform.position.y + 3.5f){ 
				 frogController.MoveUp();
	            }
			else if (Input.GetButtonDown(downButton)){
				frogController.MoveDown();
	            }
			else if (Input.GetButtonDown(rightButton)){
				frogController.MoveRight();
	            }
			else if (Input.GetButtonDown(leftButton)){
				frogController.MoveLeft();
	            }
	    }
	}
}
