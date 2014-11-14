using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
	public GameObject hand;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OncollisionEnter (Collision col) {
		{
			if(col.gameObject.name == "Cylinder")
			{
				Destroy(col.gameObject);
			}
		}
}
}