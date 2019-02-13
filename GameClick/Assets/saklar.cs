﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class saklar : MonoBehaviour {
	private float timerku = 1.5f;
	private int numRand,score,live,highscore,counter;
	public GameObject[] gridObj;
	public GameObject cbg,panelGameover,jumpscare;
	private bool bgcam=true;
	public Text txtScore,txtLive,txtHighscore;
	// Use this for initialization
	void Start () {
		resetGame ();
	}
	
	// Update is called once per frame
	void Update () {
		txtScore.text = "Score : " + score;
		txtLive.text = "Lives : " + live;
		txtHighscore.text = "Highscore : " + highscore;
		if (live == 0) {
			if(score>PlayerPrefs.GetInt("highscore")){
				highscore=score;
				PlayerPrefs.SetInt("highscore",highscore);
			}

			Debug.Log ("Game over");
			panelGameover.SetActive (true);
		} else {
			timerku -= Time.deltaTime;
			numRand = Random.Range (0,9);
			Debug.Log ("Posisi : "+numRand);
			if (Mathf.Round (timerku) == 0) {
				respawn ();
				live -= 1;
			}
		}
			
	}

	void OnMouseDown(){
		
		Debug.Log ("Ditekan");
		if (bgcam) {
			cbg.GetComponent<Camera> ().backgroundColor = Color.black;
			bgcam = false;
		} else {
			cbg.GetComponent<Camera> ().backgroundColor = Color.white;
			bgcam = true;
		}
		transform.Rotate (0, -180, 180);
		score += 1;
		counter += 1;
		if (counter >= 10) {
			jumpscare.SetActive (true);
			counter = 0;
		} else {
			jumpscare.SetActive(false);
		}
		respawn ();
	}

	void respawn(){
		transform.position = gridObj [numRand].transform.position;
		timerku = 1.5f;
	}

	void resetGame(){
		score = 0;
		live = 3;
		panelGameover.SetActive (false);
		highscore = PlayerPrefs.GetInt ("highscore");

	}

	public void replayGame(){
		resetGame ();
	}

	public void goHigh(){
		SceneManager.LoadScene ("highscore");
	}

}
