using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public AudioClip mp3File;
	public AudioSource lagu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!lagu.isPlaying) {
			//Debug.Log ("MUSIK ON");
			lagu.clip = mp3File;
			lagu.Play ();
		}
	}
}
