using UnityEngine;
using System.Collections;

public class FallingCube : MonoBehaviour {
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
		allBodys[chosenOne].isKinematic = false;
		allBodys[chosenOne].useGravity = true;
	}

}
