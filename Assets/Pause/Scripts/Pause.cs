using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {
	
	public GameObject pausePanel;
	private bool isPaused;
	// Use this for initialization
	void Start () {
		pausePanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () { 

		if (Input.GetKeyDown (KeyCode.Escape)) { //Våran InputManager har satt Cancel på Escape key som default
			SwitchState();
		}
	}

	public void SwitchState(){
		if(isPaused){
			Time.timeScale = 0.0f; //Paused
			pausePanel.SetActive (false);
			isPaused = false;
		} else {
			Time.timeScale = 1.0f; // Unpaused
			pausePanel.SetActive (true);
			isPaused = true;
		}
	}

	public void ExitToMain(){
		//Application.LoadLevel();
	}

}