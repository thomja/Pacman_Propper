using UnityEngine;
using System.Collections;
/*----------------------CODED BY THOMAS SP15--------------------------*/
public class MoveScript : MonoBehaviour {
	private int myDirection = 0;
	private bool moveForward;
	private bool willFall;
	public float speed = 1;
	public GameObject[] myBoxes;
	public BoxChecker[] myBoxCheckers;
	public Vector3 startPosition;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		//Returning other instances to variables.
		for(int i = 0; i < myBoxes.Length; i++){
			myBoxCheckers[i] = myBoxes[i].GetComponent<BoxChecker>();
		}
		startPosition = transform.position;
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
		//Vector3.Distance(hit.collider.gameObject.transform.position, transform.position)
		if (Physics.Raycast(transform.position, Vector3.down, out hit) && Vector3.Distance(hit.collider.gameObject.transform.position, transform.position) > 2) {
			//Debug.Log (Vector3.Distance(hit.collider.gameObject.transform.position, transform.position));
			//print(hit.collider.gameObject.name);
			willFall = true;
			if(this.GetComponent<Rigidbody>().isKinematic == true){
				this.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
				this.GetComponent<Rigidbody>().isKinematic = false;
				this.GetComponent<Rigidbody>().useGravity = true;
				//this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);
			}
		}
	}

	void FixedUpdate(){
		if (myBoxCheckers [0].boxClear == true && moveForward == true && willFall == false) {
			transform.Translate (new Vector3 (0f, 0f, 1f) * speed);
		}
	}
	public void ResetPosition(){
		transform.position = startPosition;
	}
}
