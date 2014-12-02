using UnityEngine;
using System.Collections;

public class HandsColliderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		((CharacterScript)col.gameObject.GetComponent(typeof(CharacterScript))).hit(5);
	}
}
