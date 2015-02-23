using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public static FollowCam S; // Singleton Instance

	// Fields shown in Unity Inspector pane
	public float easing = 0.05f;
	public Vector2 minXY;

	// Fields set dynamically	
	public GameObject poi; // The Point Of Interest
	private float camZ; // Desired Camera Z Position
	
	
	void Awake () {
		S = this;
		camZ = this.transform.position.z;
	}
	
	void FixedUpdate () {
		// If the point of interest is empty, do nothing
		if(poi == null) return;

		// Get the poi's position
		Vector3 destination = poi.transform.position;

		// Limit the X and Y to minimum values
		destination.x = Mathf.Max (minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.y);

		// Interpolate between current camera position and poi
		destination = Vector3.Lerp(transform.position, destination, easing);

		// Save the camZ in this destination
		destination.z = camZ;

		// Set camera to this destination
		transform.position = destination;

		// Set OrthographicSize of camera to keep the ground in view
		this.camera.orthographicSize = destination.y + 10;
	}
}
