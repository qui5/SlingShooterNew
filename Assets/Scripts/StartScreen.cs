using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	public AudioClip StartSound;
	public float startVol = 1f;

	private AudioSource source;

	void OnMouseDown (){
		source = GetComponent<AudioSource>();
		source.PlayOneShot(StartSound,startVol);
	}

	void OnMouseUp(){
		Application.LoadLevel ("Game");
	}

}