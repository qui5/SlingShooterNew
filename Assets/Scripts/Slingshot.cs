using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	// Fields set in the Unity Inspector pane
	public GameObject prefabProjectile;
	public float velocityMult = 4f;
	
	// Fields set dynamically
	private GameObject launchPoint;
	private Vector3 launchPos;
	private GameObject projectile;
	private bool aimingMode;
	
	void Awake(){
		//print ("Awake()");
		launchPoint = GameObject.Find("LaunchPoint");
		launchPoint.SetActive(false);
		launchPos = launchPoint.transform.position;
	}
	
	void OnMouseEnter() {
		//print ("Enter");
		launchPoint.SetActive(true);
	}
	
	void OnMouseExit() {
		//print ("Exit");
		launchPoint.SetActive(false);
	}
	
	void OnMouseDown(){
		//print ("Down");

		// Player pressed mouse while over Slingshot
		aimingMode = true;

		// Instantiate a projectile
		projectile = Instantiate(prefabProjectile) as GameObject;

		// Start it at launch position
		projectile.transform.position = launchPos;

		// Set it to kinematic for now
		projectile.rigidbody.isKinematic = true;
	}
}
