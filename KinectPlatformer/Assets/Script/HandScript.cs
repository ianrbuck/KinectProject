using UnityEngine;
using System.Collections;


public class HandScript : MonoBehaviour {
	public GameObject elbow;
	public GameObject wrist;
	public bool right;
	public Vector3 moveDirection;
	public Vector3 lastPosition;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posElb = elbow.transform.position;
		Vector3 posWri = wrist.transform.position;
	
		Vector3 vec = posWri - posElb;
		//print ("vector : " + vec);

		transform.position = posWri;
		moveDirection = posWri - lastPosition;
		print (moveDirection.magnitude);
		if (moveDirection.magnitude > 0.2) {
			if (right) {
				//this.transform.LookAt (posWri + moveDirection);
				this.transform.LookAt (posElb);
				this.transform.Rotate (-90, 0, 0);
			} else {
				this.transform.LookAt (posWri + moveDirection);
				this.transform.Rotate (90, 0, 0);
			}
		} else {
			if (right) {
				this.transform.LookAt (posElb);
				this.transform.Rotate (-90, 0, 0);
			} else {		
				this.transform.LookAt (posElb + (2 * vec));
				this.transform.Rotate (90, 0, 0);
			}
		}
		lastPosition = posWri;
	}
	void OnCollisionEnter (Collision col) {
		((CharacterScript)col.gameObject.GetComponent(typeof(CharacterScript))).hit(5);
	}
}
