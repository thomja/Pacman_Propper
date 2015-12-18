using UnityEngine;
using System.Collections;
/*----------------------CODED BY THOMAS SP15--------------------------*/
public class MoveScript : MonoBehaviour {
	private int myDirection = 0;
	public float speed = 1;
	private bool moveForward;
	public GameObject[] myBoxes;
	public BoxChecker[] myBoxCheckers;
	// Use this for initialization
	void Start () {
		//Returning other instances to variables.
		for(int i = 0; i < myBoxes.Length; i++){
			myBoxCheckers[i] = myBoxes[i].GetComponent<BoxChecker>();
		}
	}
	
	//Check the value of myDirection, if 1 then turn 90 degrees. If 2, turn -90 degrees. Set myDirection to 0.
	void CheckTurn(){
		if(myDirection == 1 && myBoxCheckers[1].boxClear == true){
			transform.Rotate(0f, 90f, 0f);
			myDirection = 0;
		} else if (myDirection == 2 && myBoxCheckers[2].boxClear == true){
			transform.Rotate(0f, -90f, 0f);
			myDirection = 0;
		}
	}

	//Checks if the front box has an object in it. If not, then move forward.
	//Checks key and then set myDirection value that the CheckTurn() controls.
	//If S is pressed then turn backwards, because there is never a wall following you.
	void Update () {
		CheckTurn ();
		if (myBoxCheckers [0].boxClear == true && moveForward == true) {
			transform.Translate (new Vector3 (0f, 0f, 1f) * speed);
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			moveForward = true;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			transform.Rotate (0f, 180f, 0f);
			myDirection = 0;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			myDirection = 2;
			CheckTurn ();
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			myDirection = 1;
			CheckTurn ();
		}
	}
}
