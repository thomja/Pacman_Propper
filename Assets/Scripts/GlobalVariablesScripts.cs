using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class GlobalVariablesScripts : MonoBehaviour {
	//Do not like to have this many variables in one script but I deem it necessary.
	public GameObject pacman;
	public int pillCounter;
	public GameObject[] pillCount;
	public int life = 3;
	public int level = 1;
	public int totalScore;
	public int coinScore;
	public int diamondPoint;
	public int FruitPoint;
	public int boosterPoint;
	public Text text;
	public Text finishText;

	// Use this for initialization
	void Start () {
		//text.text = "Level: " + level.ToString() + " Score: " + totalScore.ToString();
		pillCount = GameObject.FindGameObjectsWithTag("Pill").Concat(GameObject.FindGameObjectsWithTag("SuperPill")).ToArray();
		pillCounter = pillCount.Length;
		//-------------------For debugging, will remove later-------------------
		/*
		for(int i = 10; i < pillCount.Length; i++){
			pillCount[i].SetActive(false);
		}
		pillCounter = 10;
		*/
		//-------------------For debugging, will remove later------------------- 	
	}
	
	// Update is called once per frame
	void Update () {
		if(pillCounter == 0 && Input.GetKeyDown (KeyCode.Space)){
			RespawnAllPills();
			level = level + 1;
		}
	
	}

	public void UpdateScore(int score){
		totalScore = totalScore + score;
		text.text = "Level: " + level.ToString() + " Score: " + totalScore.ToString();
	}

	public void GameStateChecker(){
		pillCounter = pillCounter - 1;
		if(pillCounter == 0){
			finishText.text = "You have completed the level! Press space to continue to the next level";
		}
	}

	public void RespawnAllPills(){
		for(int i = 0; i < pillCount.Length; i++){
			pillCount[i].SetActive(true);
		}
		finishText.text = "";
		text.text = "Level: " + level.ToString() + " Score: " + totalScore.ToString();	
		pacman.GetComponent<MoveScript>().ResetPosition();
		pillCounter = pillCount.Length;
	}
}
