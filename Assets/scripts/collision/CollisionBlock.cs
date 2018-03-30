using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBlock : MonoBehaviour {


	// Use this for initialization
	void Start () {
		this.name = this.transform.parent.name + "." + this.name;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
