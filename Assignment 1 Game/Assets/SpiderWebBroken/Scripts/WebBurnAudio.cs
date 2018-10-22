using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebBurnAudio : MonoBehaviour {

	public AudioClip SoundToPlay;

	private AudioSource audioFX;

	// Use this for initialization
	void Start () {

		audioFX = gameObject.GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void OnTriggerStay(Collider plyr)
	{
		if (plyr.tag == "Player" && Input.GetMouseButtonDown (0)) 
		{
			audioFX.clip = SoundToPlay;
			audioFX.Play ();
		
		}
		
	}
}
