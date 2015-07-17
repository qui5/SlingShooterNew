using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public GameObject splashParticle;
	public AudioClip HitSound;
	public AudioClip SplashSound;
	public float projectileVol = 1f;
	public int maxHitNum = 3;
	
	private AudioSource source;
	private int hitNum = 0;

	void OnCollisionEnter(){

		if (Goal.goalMet == true) {
			StartCoroutine("waitAndDestroy");
		}

		source = GetComponent<AudioSource>();
		source.PlayOneShot(HitSound,projectileVol);

		hitNum++;
		checkHit ();
	}

	void checkHit(){
		if (hitNum == maxHitNum) {
			Instantiate (splashParticle, this.gameObject.transform.position, this.gameObject.transform.rotation);
			source.PlayOneShot(SplashSound,projectileVol);
			StartCoroutine("waitAndDestroy");
		}
		else return;
	}

	IEnumerator waitAndDestroy(){
		yield return new WaitForSeconds (0.2f);
		Destroy(this.gameObject);

		GameObject[] particles = GameObject.FindGameObjectsWithTag("Particle");
		for (int i=0; i<particles.Length; i++){
			Destroy(particles[i]);
		}
	}
}