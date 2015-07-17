using UnityEngine;
using System.Collections;

public class SandCube : MonoBehaviour {

	public int maxHitNum = 1;
	private int hitNum = 0;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Projectile") {		
			hitNum++;
			checkHit ();
		}
	}

	void checkHit(){
		if (hitNum == maxHitNum) {
			StartCoroutine("waitAndDestroy");
		}
		else return;
	}

	IEnumerator waitAndDestroy(){
		yield return new WaitForSeconds (0.2f);
		Destroy (this.gameObject);
	}


}
