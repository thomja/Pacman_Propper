using UnityEngine;
using System.Collections;

public class SpeedFloor : MonoBehaviour {
	public GameObject pacman;
	public MoveScript move;
	public int multiplier;

	// Use this for initialization
	void Start () {
		move = pacman.GetComponent<MoveScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider Col){

	}
}
