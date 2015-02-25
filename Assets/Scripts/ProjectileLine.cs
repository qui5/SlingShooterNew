using UnityEngine;
using System.Collections;

// This is needed for using Lists
using System.Collections.Generic;

public class ProjectileLine : MonoBehaviour {

	public static ProjectileLine S; // Singleton instance

	// Fields in Inspector pane
	public float minDist = 0.1f;

	// Dynamic fields
	private LineRenderer line;
	private GameObject _poi;
	private List<Vector3> points;

	void Awake() {
		S = this; // Set the singleton instnce
		// Get a reference to the LineRenderer
		line = GetComponent<LineRenderer>();
		line.material = new Material(Shader.Find("Particles/Additive"));
		Color c1 = Color.yellow;
		Color c2 = Color.red;
		line.SetColors(c1,c2);

		// Disable until its needed
		line.enabled = false;
		// Init points list
		points = new List<Vector3>();
	}

	// A property: Looks to the outside like a field but internally calls get/set
	public GameObject poi {
		get {
			return _poi;
		}
		set {
			_poi = value;
			if(_poi != null) {
				// If poi was set to something (and now to something new), reset everything
				line.enabled = false;
				points = new List<Vector3>();
			}
		}
	}

	void FixedUpdate() {
		if(poi == null) {
			// If there is no poi yet, try looking at the camera
			if(FollowCam.S.poi != null) {
				if(FollowCam.S.poi.tag == "Projectile") {
					poi = FollowCam.S.poi;
				} else {
					return; // Give up, no poi found
				}
			} else {
				return; // Give up, no poi found
			}
		}

		// Now poi definitely has a value and its a projectile
		// So add a point in every FixedUpdate()
		AddPoint();
		if(poi.rigidbody.IsSleeping()){
			// The poi is resting, so clear it
			poi = null;
		}
	}

	public void AddPoint(){
		Vector3 pt = _poi.transform.position;
		// If the point isnt far enough from the last one, do nothing
		if(points.Count > 0 && (pt - lastPoint).magnitude < minDist) {
			return;
		}

		if(points.Count == 0){
			// If its the launch point (first)
			points.Add(pt);
			points.Add(pt);

			line.SetVertexCount(2);
			line.SetPosition(0, points[0]);
			line.SetPosition(1, points[1]);

			line.enabled = true;

		} else {
			// Not the first point
			points.Add(pt);
			line.SetVertexCount(points.Count);
			line.SetPosition(points.Count - 1, pt);
		}
	}

	public Vector3 lastPoint {
		get {
			if(points == null){
				return Vector3.zero;
			}
			return points[points.Count - 1];
		}
	}

}
