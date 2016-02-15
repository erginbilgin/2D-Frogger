using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrogSPController : FrogController {
	public Text highScoreText;
	public Text scoreOnPanel;

	public int GetHighScore(){
		if(!PlayerPrefs.HasKey("Score")){
			PlayerPrefs.SetInt("Score",0);
    	}
    return PlayerPrefs.GetInt("Score");
    }
     
 	public void SetHighScore(int value){
    	PlayerPrefs.SetInt("Score",value);
    }

	protected override void OnDestroy(){
		if (playerScore > GetHighScore()){
	    	SetHighScore(playerScore);
	    }
	    scoreOnPanel.text = playerScore.ToString();
		highScoreText.text = GetHighScore().ToString();
		base.OnDestroy();
	}
}
