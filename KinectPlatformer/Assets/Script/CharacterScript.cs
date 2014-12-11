using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
	// Use this for initialization
	public int hitPoints;

	void Start () {
		this.hitPoints = 25;
		gameObject.tag = "character";
	}

	public void hit(int damage) {
		this.hitPoints -= damage;
		print (this.name + " hitpoints: " + this.hitPoints);
		if (this.hitPoints <= 0) {
				Destroy(this.gameObject);
				((Creator)Camera.main.GetComponent(typeof(Creator))).majCharact();	
		}	
	}

}