using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLeftMouseClick : MonoBehaviour {

	public Component[] compoundColliders;
	// Use this for initialization
	void Start () {
		compoundColliders = GetComponentsInChildren<BoxCollider> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if(Physics.Raycast(ray, out hit)) {
				foreach (BoxCollider box in compoundColliders) {
					if (hit.transform.name == box.name)
						Destroy (this.gameObject);
				}
			}
		}
	}
}
