using UnityEngine;
using System.Collections;


public class HandScript : MonoBehaviour {
	public GameObject elbow;
	public GameObject wrist;
	public bool right;


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

		

		if (right) {
			this.transform.LookAt (posElb);
			this.transform.Rotate (-90, 0, 0); //TODO: make it go upside down when right hand
		} else {		
			this.transform.LookAt (posElb + (2* vec));
			this.transform.Rotate (90, 0, 0);
		}
	}
	void OnCollisionEnter (Collision col) {
		((CharacterScript)col.gameObject.GetComponent(typeof(CharacterScript))).hit(5);
	}
}
