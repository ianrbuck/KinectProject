using UnityEngine;
using System.Collections;


public class HandScript : MonoBehaviour {
	public GameObject elbow;
	public GameObject wrist;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos1 = elbow.transform.position;
		Vector3 pos2 = wrist.transform.position;

		transform.position = pos1;
		this.transform.LookAt (pos2);
		this.transform.Rotate (0, 90, 0);
	}
	void OnCollisionEnter (Collision col) {	
		if (col.gameObject.name == "OurCylinder") {
			print ("Captain, we had a collision!");
			((CharacterScript)col.gameObject.GetComponent(typeof(CharacterScript))).hit(5);
		}
	}
}
