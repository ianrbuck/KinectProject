using UnityEngine;
using System.Collections;

public class PointManScript : MonoBehaviour {

	public GameObject pointMan;

	// Use this for initialization
	void Start () {
		var allMyRenderers = GetComponentsInChildren<Renderer>();
		foreach( Renderer rend in allMyRenderers) {
			rend.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
