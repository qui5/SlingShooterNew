using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// A static field visible from anywhere
	public static bool goalMet = false;
	public AudioClip GoalSound;
	public float goalVol = 1f;
	public GameObject splashParticle;

	private AudioSource source;

	void OnTriggerEnter(Collider other) {
		// Check if the hit comes from a projectile
		if(other.gameObject.tag == "Projectile") {
			goalMet = true;
			// Set alpha to higher opacity
			Color c = GetComponent<Renderer>().material.color;
			c.a = 1.0f;
			GetComponent<Renderer>().material.color = c;

			Instantiate (splashParticle, this.gameObject.transform.position, this.gameObject.transform.rotation);
			source = GetComponent<AudioSource>();
			source.PlayOneShot(GoalSound,goalVol);
		}
	}
	
}
