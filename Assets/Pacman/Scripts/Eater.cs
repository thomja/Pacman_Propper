using UnityEngine;
using System.Collections;

public class Eater : MonoBehaviour {
	public GameObject globalVarScript;
	public GlobalVariablesScripts global;
	// Use this for initialization
	void Start () {
		global = globalVarScript.GetComponent<GlobalVariablesScripts>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider Col){
		if(Col.gameObject.tag == "Pill"){
			global.GameStateChecker();
			global.UpdateScore(global.coinScore);
			Col.gameObject.SetActive(false);
		} else if(Col.gameObject.tag == "SuperPill"){
			global.GameStateChecker();
			global.UpdateScore(global.diamondPoint);
			Col.gameObject.SetActive(false);
			Debug.Log ("Derp");
		}

	}
}
