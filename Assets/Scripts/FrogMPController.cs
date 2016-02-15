using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrogMPController : FrogController {
	public Text winnerText;

	protected override void OnDestroy(){
		if (isGameActive){
			if (isSecondPlayer)
			winnerText.text = "Green";
			if (!isSecondPlayer)
			winnerText.text = "Red";
		}
		base.OnDestroy();
	}
}
