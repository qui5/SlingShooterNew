using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public GameObject splashParticle;

	void OnTriggerEnter(Collider other){
		Instantiate (splashParticle, this.gameObject.transform.position, this.gameObject.transform.rotation);
	}

}
