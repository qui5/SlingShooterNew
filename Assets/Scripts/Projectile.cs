using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	void onCollisionEnter(Collision col) {
		if (col.gameObject.name == "Ground") {
			Explode ();
		}
	}

	void Explode() {
		var exp = GetComponent<ParticleSystem>();
		exp.Play();
		Destroy(gameObject, exp.duration);
	}
}
