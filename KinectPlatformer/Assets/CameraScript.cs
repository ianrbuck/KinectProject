﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject head;
	public static int delay = 10;
	public Vector3[] pastOrientations = new Vector3[delay];
	public int currentIndex = 0;
	public Vector3 currentOrientation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = head.transform.position - (transform.forward * 2);
		currentOrientation = this.transform.FindChild("OVRCameraController").FindChild("CameraLeft").transform.eulerAngles;
		pastOrientations [currentIndex] = currentOrientation;
		currentIndex++;
		if (currentIndex >= delay) {
			currentIndex -= delay;
		}
		if (pastOrientations [currentIndex].y - currentOrientation.y > 45
			|| currentOrientation.y - pastOrientations [currentIndex].y > 45) {
			((Creator)Camera.main.GetComponent(typeof(Creator))).Create();
			print ("Rapid horizontal movement detected");
		}
		if (pastOrientations [currentIndex].x - currentOrientation.x > 45
			|| currentOrientation.x - pastOrientations [currentIndex].x > 45) {
			print ("Rapid vertical movement detected.");
		}

	}
}
