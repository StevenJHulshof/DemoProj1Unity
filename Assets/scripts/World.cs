using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	public enum TileType {
		Grass,
		Stone
	}

	public TileType massType = TileType.Grass;
	public int massSize;

	public TileType patchType = TileType.Stone;
	public int patchSize;

	//Tiles
	public Transform[] tiles;

	// Use this for initialization
	void Start () {

		// Generator.createMass(landMassType);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
