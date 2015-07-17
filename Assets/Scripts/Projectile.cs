using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public GameObject splashParticle;
	public AudioClip HitSound;
	public float hitVol = 1f;
	
	private AudioSource source;

	void OnCollisionEnter(){
		Instantiate (splashParticle, this.gameObject.transform.position, this.gameObject.transform.rotation);
		source = GetComponent<AudioSource>();
		source.PlayOneShot(HitSound,hitVol);
	}

}
