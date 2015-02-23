using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	private GameObject launchPoint;

	void Awake(){
		//print ("Awake()");
		launchPoint = GameObject.Find("LaunchPoint");
		launchPoint.SetActive(false);
	}

	void OnMouseEnter() {
		//print ("Enter");
		launchPoint.SetActive(true);
	}
	
	void OnMouseExit() {
		//print ("Exit");
		launchPoint.SetActive(false);
	}
}
