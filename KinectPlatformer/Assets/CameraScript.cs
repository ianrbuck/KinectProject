using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject head;
	// Use this for initialization
	void Start () {
		((Creator)Camera.main.GetComponent(typeof(Creator))).Create();
		((Creator)Camera.main.GetComponent(typeof(Creator))).Create();
		((Creator)Camera.main.GetComponent(typeof(Creator))).Create();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = head.transform.position - (transform.forward * 2);

	}
}
