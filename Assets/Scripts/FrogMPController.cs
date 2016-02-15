using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FrogMPController : FrogController {
	public Text winnerText;
	public static List<string> playersList = new List<string>();

	protected override void Start(){
		playersList.Add(frogName);
		base.Start();
	}

	protected override void OnDestroy(){
		if (isGameActive){
			playersList.Remove(frogName);
		}
		if (playersList.Count < 2 && playersList.Count > 0){
			winnerText.text = playersList[0];
			base.OnDestroy();
			playersList = new List<string>();
		}
	}
}
