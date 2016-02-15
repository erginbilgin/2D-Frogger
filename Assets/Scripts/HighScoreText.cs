using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour {
	public Text highScoreText;

	public int GetHighScore(){
		if(!PlayerPrefs.HasKey("Score")){
			PlayerPrefs.SetInt("Score",0);
    	}
    return PlayerPrefs.GetInt("Score");
    }

	// Use this for initialization
	void Start () {
		highScoreText.text = GetHighScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
