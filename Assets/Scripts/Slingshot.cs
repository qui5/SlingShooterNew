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

	void Update() {
		// If the Slingshot is not in aiming mode, don't run this code
		if(!aimingMode) return;

		// Get the current mouse position in 2D screen coordinates
		Vector3 mousePos = Input.mousePosition;
		// Convert the mouse position to 3D world coordinates
		mousePos.z = - Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos);

		// Find the delta from launch position to 3D mouse position
		Vector3 mouseDelta = mousePos3D - launchPos;

		// Limit mouseDelta to the radius of the Slingshot SphereCollider
		float maxMagnitude = GetComponent<SphereCollider>().radius;
		if(mouseDelta.magnitude > maxMagnitude){
			mouseDelta.Normalize();
			mouseDelta *= maxMagnitude;
		}

		// Now move the projectile to this new position
		projectile.transform.position = launchPos + mouseDelta;
		
		if(Input.GetMouseButtonUp(0)) {
			// The mouse has been released
			aimingMode = false;
			// Fire off the projectile with given velocity
			projectile.rigidbody.isKinematic = false;
			projectile.rigidbody.velocity = -mouseDelta * velocityMult;
			// Set the reference to the projectile to null as early as possible
			projectile = null;
		}
		
	}
}
