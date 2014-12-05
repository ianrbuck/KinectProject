using UnityEngine;
using System.Collections;


public class HandScript : MonoBehaviour {
	public GameObject elbow;
	public GameObject wrist;
	public bool right;
	public Vector3 moveDirection;
	public Vector3 lastPosition;
	public int framesHoriz;
	public int framesVert;


	// Use this for initialization
	void Start () {
		framesVert = 0;
		framesHoriz = 0;
	}
	
	// Update is called once per frame
	void Update () {
		int latency = 1;
		double maxVert = 0.015;
		Vector3 posElb = elbow.transform.position;
		Vector3 posWri = wrist.transform.position;
	
		Vector3 vec = posWri - posElb;
		//print ("vector : " + vec);

		transform.position = posWri;
		moveDirection = posWri - lastPosition;
		//print (moveDirection.magnitude);
		if (moveDirection.magnitude > 0.07) {

			if ((Mathf.Abs(moveDirection.x)  > Mathf.Abs(moveDirection.y) )||(Mathf.Abs(moveDirection.z)  > Mathf.Abs(moveDirection.y ))) {
					//Move horizontal
					//print( " horiz x: "+ moveDirection.x+ " y: " +moveDirection.y + "z:"+moveDirection.z);
					//print ("Move horizontal");
					framesHoriz++;
					framesVert = framesVert - 3;
			} else {
					//Move vertical
					//print( "vertical x: "+ moveDirection.x+ " y: " +moveDirection.y + "z:"+moveDirection.z);
					//print ("Move vertical");
					framesHoriz = framesHoriz - 3;
					framesVert++;
			}
		} else {
			//no significant movement
			framesHoriz--;
			framesVert--;
		}

		if(framesVert <0){
			framesVert=0;
		}
		if(framesHoriz <0) {
			framesHoriz=0;
		}
		if(  framesHoriz - framesVert > latency){
			rotateHorizontal(posElb, vec);
		}
		else {
			rotateVertical(posElb,vec);
		}

		lastPosition = posWri;

	}

	void rotateVertical(Vector3 posElb,Vector3 vec){
		if (right) {
			this.transform.LookAt (posElb);
			this.transform.Rotate (-90, 0, 0);
		} else {
			this.transform.LookAt (posElb + (2 * vec));
			this.transform.Rotate (90, 0, 0);
		}
	}
	void rotateHorizontal(Vector3 posElb,Vector3 vec){
		if (right) {
			this.transform.LookAt (posElb);
			this.transform.Rotate (-90, 0, 0);
			this.transform.Rotate (0, -90, 0);
		} else {
			this.transform.LookAt (posElb + (2 * vec));
			this.transform.Rotate (90, 0, 0);
			this.transform.Rotate (0, 90, 0);
		}
	}

	void OnCollisionEnter (Collision col) {
		((CharacterScript)col.gameObject.GetComponent(typeof(CharacterScript))).hit(5);
	}
}
