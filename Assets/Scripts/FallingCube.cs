using UnityEngine;
using System.Collections;

public class FallingCube : MonoBehaviour {
	public GameObject coinCheckBox;
	public float repeatingTime;
	public float startTime;
	public GameObject floorParent;
	public Rigidbody[] allBodys;

	// Use this for initialization
	void Start () {
		allBodys = floorParent.GetComponentsInChildren<Rigidbody>();
		startFloorFall();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startFloorFall(){
		InvokeRepeating("floorFall", startTime, repeatingTime);
	}

	void floorFall(){
		int chosenOne = Mathf.CeilToInt(Random.Range(0,allBodys.Length));
		coinCheckBox.GetComponent<CoinChecker>().isCoinHere = false;
		Debug.Log ("Moving");
		coinCheckBox.transform.position = new Vector3(allBodys[chosenOne].transform.position.x,
		                                              allBodys[chosenOne].transform.position.y + 1.5f,
		                                              allBodys[chosenOne].transform.position.z);
		if(coinCheckBox.GetComponent<CoinChecker>().isCoinHere == false){
			Debug.Log ("Falling");
			allBodys[chosenOne].isKinematic = false;
			allBodys[chosenOne].useGravity = true;
		} else {
			Debug.Log ("There is a coin here");
		}
	}

}
