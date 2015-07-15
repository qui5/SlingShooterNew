using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Wall_Stone") {
			Destroy (this.gameObject);
		}
	}

	/*void Explode() {
		var exp = GetComponent<ParticleSystem>();
		exp.Play();
		Destroy(gameObject, exp.duration);
	}*/
}
