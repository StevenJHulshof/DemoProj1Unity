using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	public enum BulletState {
		Idle,
		Ricochet,
		Destroy
	}
		
	public AudioClip[] bulletRicochetClip;

	private AudioSource bulletRicochetAudio;
	private BulletState state = BulletState.Idle;
	// Use this for initialization
	void Start () {
		bulletRicochetAudio = gameObject.AddComponent < AudioSource > ();
		bulletRicochetAudio.clip = bulletRicochetClip [0];
		bulletRicochetAudio.playOnAwake = false;
		bulletRicochetAudio.loop = false;
	}
	
	// Update is called once per frame
	void Update () {

		switch (state) {
		case BulletState.Ricochet:
			int clip = Random.Range (0, bulletRicochetClip.Length);
			bulletRicochetAudio.clip = bulletRicochetClip [clip];
			bulletRicochetAudio.Play ();
			state = BulletState.Destroy;
			break;
		case BulletState.Destroy:
			GetComponent<Renderer> ().enabled = false;
			if(!bulletRicochetAudio.isPlaying)
				Destroy (this.gameObject);
			break;
		default:
			break;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.layer != 8 && state == BulletState.Idle) {
			state = BulletState.Ricochet;
		} else if (state == BulletState.Idle) {
			state = BulletState.Destroy;
		} 
	}
}
