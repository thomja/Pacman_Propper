using UnityEngine;
using System.Collections;

public class CoinChecker : MonoBehaviour {
	public bool isCoinHere = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider Col){
		if(Col.gameObject.tag == "Pill"){
			isCoinHere = true;
			Debug.Log ("True");
		} 
	}
}
