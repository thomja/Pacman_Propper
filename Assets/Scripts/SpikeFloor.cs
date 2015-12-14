using UnityEngine;
using System.Collections;

public class SpikeFloor : MonoBehaviour {
	//Kodat av Thomas
	//Kan sätta in Lerp om man pallar för snygghet
	public GameObject Spikes;
	public int delay;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpikeUp", delay, delay);
		InvokeRepeating("SpikeDown", delay * 1.5f, delay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpikeUp(){
		Spikes.transform.Translate(Vector3.up);
	}
	void SpikeDown(){
		Spikes.transform.Translate(Vector3.down);
	}
}
