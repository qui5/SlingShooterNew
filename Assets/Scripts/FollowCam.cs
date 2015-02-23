using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public static FollowCam S; // Singleton Instance

	// Fields shown in Unity Inspector pane

	// Fields set dynamically	
	public GameObject poi; // The Point Of Interest
	private float camZ; // Desired Camera Z Position
	
	
	void Awake () {
		S = this;
		camZ = this.transform.position.z;
	}
	
	void Update () {
		// If the point of interest is empty, do nothing
		if(poi == null) return;

		// Get the poi's position
		Vector3 destination = poi.transform.position;
		// Save the camZ in this destination
		destination.z = camZ;
		// Set camera to this destination
		transform.position = destination;
	}
}
