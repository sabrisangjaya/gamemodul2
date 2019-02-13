using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class highscore : MonoBehaviour {
	public Text txtHighscore;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		txtHighscore.text="Highscore : "+PlayerPrefs.GetInt("highscore");
	}

	public void playGame(){
		SceneManager.LoadScene ("gameplay");
	}

	public void resetHigh(){
		PlayerPrefs.SetInt("highscore",0);
	}
		
}
