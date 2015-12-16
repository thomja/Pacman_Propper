using UnityEngine;
using System.Collections;

public class CoinFlyDown : MonoBehaviour {
	public float desiredYAxis;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(244.8016f, Mathf.Lerp(transform.position.y, desiredYAxis, Time.time/ 10), 279.4767f);
	}
}
