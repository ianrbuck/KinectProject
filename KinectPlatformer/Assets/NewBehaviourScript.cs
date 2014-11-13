using UnityEngine;
using System.Collections;


public class NewBehaviourScript : MonoBehaviour {
	public GameObject wrist;
	public GameObject hand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos1 = wrist.transform.position;
		Vector3 pos2 = hand.transform.position;

		transform.position = pos1;
		this.transform.LookAt (pos2);
	}
}
