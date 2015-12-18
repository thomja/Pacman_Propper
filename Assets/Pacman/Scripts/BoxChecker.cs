using UnityEngine;
using System.Collections;
/*----------------------CODED BY THOMAS SP15--------------------------
Code may not be the prettiest by any stretch of the imagination! This is due to us being new to scrum, poor planning, and Dreamhack
My aim has so far not to make it pretty, just to make sure that it works.*/
public class BoxChecker : MonoBehaviour {
	public int isColliding = 0;
	public bool boxClear;
	// Use this for initialization
	void Start () {
		boxClear = true;
	}

	// Update is called once per frame
	void Update () {

	}

	//On these two methods please note that isColliding and boxClear are essentials. isColliding checks if the box is currently in a wall.
	//I can't have this set to a bool because the true/false values would sometimes be incorrect due to the boxes entering objects
	//before exiting previous ones. boxClear is there to be a result depending on isColliding. I could just check for isCollidings value
	//from other scripts but I have had some issues with unity being slow on updating it so I use a bool value that is not being updated as frequently.

	void OnTriggerExit(Collider Col){
		//Should be optimised and not use so many != statements.
		//Checks if it's not exiting objects with the tags Terrain, Pill, SuperPill, Ghost and teleporter.
		//If it is, -1 on isCollidingand check for a clear box.
		if(Col.gameObject.tag != "Terrain" && Col.gameObject.tag != "Pill" && Col.gameObject.tag != "SuperPill" && Col.gameObject.tag != "Ghost" && Col.gameObject.tag != "Teleporter" && Col.gameObject.tag != "fruitPill"){
			isColliding -= 1;
			if(isColliding == 0){
				boxClear = true;
			}
		}
	}
		
	void OnTriggerEnter(Collider Col){
		//Checks if it enters any object with the tags Terrain, Pill, SuperPill, Ghost && Teleporter.
		//If it is, +1 on isColliding and set boxClear to false
		if(Col.gameObject.tag != "Terrain" && Col.gameObject.tag != "Pill" && Col.gameObject.tag != "SuperPill" && Col.gameObject.tag != "Ghost" && Col.gameObject.tag != "Teleporter" && Col.gameObject.tag != "fruitPill"){
			isColliding += 1;
			boxClear = false;
		}
	}
}
