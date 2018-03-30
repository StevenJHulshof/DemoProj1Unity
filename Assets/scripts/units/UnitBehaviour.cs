using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour {

	public enum UnitState {
		Idle,
		Move,
		Shoot
	}

	UnitState state = UnitState.Idle;

	public enum GunShotTail {
		Generic,
		Hallway,
		Mountain,
		Room,
		Street
	}

	public GunShotTail gunShotTail = GunShotTail.Generic;

	public AudioClip[] gunShotClips;
	public AudioClip[] gunShotTailClips;

	private AudioSource gunShotAudio;
	private AudioSource gunShotTailAudio;

	public float unitHeight = 2.0f;
	public float bulletSpeed = 10000.0f;
	public float rotationSpeed = 1000;
	private bool selected = false;
	public GameObject hexagonGrid;
	public GameObject bullet;

	private Animator animator;
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();

		gunShotAudio = gameObject.AddComponent <AudioSource> ();
		gunShotAudio.playOnAwake = false;
		gunShotAudio.loop = false;

		gunShotTailAudio = gameObject.AddComponent <AudioSource>();
		if(gunShotTailClips.Length != 0)
			gunShotTailAudio.clip = gunShotTailClips [(int) gunShotTail];
		gunShotTailAudio.playOnAwake = false;
		gunShotTailAudio.loop = false;
	}
	
	// Update is called once per frame
	void Update () {

		switch (state) {
		case UnitState.Shoot:
			
			break;
		default:
			break;

		}
		detectHit ();
		onSelected ();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.layer == 9)
			Destroy (this.gameObject);
	}

	void detectHit()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.name == this.name)
					selected = true;
				else
					selected = false;
			} else
				selected = false;
		}
	}

	void onSelected()
	{
		if (selected) {
			GetComponent<Collider> ().enabled = false;


			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {

				Vector3 direction = (hit.transform.position - this.transform.position).normalized;
				Debug.DrawLine (this.transform.position, hit.transform.position, Color.red, Mathf.Infinity);
				this.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(this.transform.forward, new Vector3(direction.x, 0, direction.z), rotationSpeed * Time.deltaTime, 0));
				if (Input.GetMouseButtonDown (1) && !animator.GetBool("Shoot")) {

					animator.SetBool ("Shoot", true);
					int clip = Random.Range (0, gunShotClips.Length);
					GameObject b = Instantiate (bullet) as GameObject;
					b.transform.parent = this.transform;
					b.transform.position = this.transform.position + new Vector3 (0, unitHeight * 0.5f , 0);
					b.GetComponent<Rigidbody> ().AddForce(direction * bulletSpeed * Time.fixedDeltaTime);
					gunShotAudio.clip = gunShotClips [clip];
					gunShotAudio.Play ();
					gunShotTailAudio.Play ();

					Destroy (b, 2.0f);
				}
			}
		} else {
			GetComponent<Collider> ().enabled = true;
		}
	}
}
