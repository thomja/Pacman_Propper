using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	/*----------------------CODED BY THOMAS SP15--------------------------*/
	public Vector3 teleportTo;
	public float spawnDelay;
	public GameObject pacman;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider Col){
		StartCoroutine(teleport(Col));
	}

	IEnumerator teleport(Collider Col){
		yield return new WaitForSeconds(spawnDelay);
		pacman.transform.position = teleportTo;
	}

}
