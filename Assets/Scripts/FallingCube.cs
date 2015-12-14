using UnityEngine;
using System.Collections;

public class FallingCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider Col){
		if(Col.gameObject.tag == "Eater"){
			this.gameObject.GetComponent<Rigidbody>().useGravity = true;
		}
	}
}
