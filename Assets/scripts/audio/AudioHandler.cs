using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour {

	public AudioSource addAudio(AudioClip clip, bool loop, bool playAwake, float volume)
	{
		AudioSource audioSource = gameObject.AddComponent <AudioSource> ();

		audioSource.clip = clip;
		audioSource.playOnAwake = playAwake;
		audioSource.loop = loop;
		audioSource.volume = volume;
	
		return audioSource;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
