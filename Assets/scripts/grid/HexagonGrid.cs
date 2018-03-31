using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonGrid : MonoBehaviour {

	public enum BaseTileType
	{
		Grass,
		Stone
	}

	public BaseTileType baseTileType = BaseTileType.Grass;

	public Transform[] tiles;
	public Transform unit;
	public Transform[] trees;

	public int N = 3;
	public int layerStart = 0;
	public int layerStop = 3;

	public const float tileHeight = 4.0f;
	public const float tileWidth = 3.464f;
	public const float tileLayerHeight = 0.3f;

	public Vector3 gridToScreen(Vector4 gridPosition) {

		return new Vector3 (
			tileWidth * gridPosition.x * 0.5f - tileWidth * gridPosition.y * 0.5f,
			0,
			tileHeight * 0.75f * gridPosition.z
		);
	}

	Transform createTransform (Transform transform, Vector4 gridPosition, float yPositionOffset){
		Transform tf = Instantiate (transform) as Transform;
		tf.GetComponent<PositionManager>().gridPosition = gridPosition;
		tf.parent = this.transform;
		tf.position = gridToScreen (tf.GetComponent<PositionManager>().gridPosition);
		tf.position += new Vector3(0.0f, yPositionOffset, 0.0f);
		return tf;
	}

	// Use this for initialization
	void Start () {
		int unitNum = 0;
		int treeNum = 0;

		for (int x = -N; x <= N; x++) {
			for(int y = Mathf.Max(-N, -x - N); y <= Mathf.Min(N, -x + N); y++)
			{
				int z = -x - y;
				int w = Random.Range (layerStart, layerStop);

				Transform t = createTransform (tiles[(int) baseTileType], new Vector4(x, y, z, w), tileLayerHeight * w * 0.5f - 0.5f * tileLayerHeight);
				t.localScale += new Vector3(0, 0, w);
				t.name = "GrassTile (" + x + ", " + y + ", " + z + ", " + w + ")";

				if (Random.Range (0.0f, 100.0f) < 10.0f && t.GetComponent<TileBehaviour> ().occupation == TileBehaviour.Occupation.Nothing) {
					
					Transform un = createTransform (unit, new Vector4 (x, y, z, w), tileLayerHeight * w);
					un.name = "Unit " + unitNum + " (" + x + ", " + y + ", " + z + ", " + w + ")";
					t.GetComponent<TileBehaviour> ().occupation = TileBehaviour.Occupation.Unit;
					unitNum++;
				}

				if (Random.Range (0.0f, 100.0f) < 30.0f && t.GetComponent<TileBehaviour> ().occupation == TileBehaviour.Occupation.Nothing) {

					Transform tr = createTransform (trees[Random.Range(0, trees.Length)], new Vector4 (x, y, z, w), tileLayerHeight * w);
					tr.name = "Tree " + treeNum + " (" + x + ", " + y + ", " + z + ", " + w + ")";
					t.GetComponent<TileBehaviour> ().occupation = TileBehaviour.Occupation.Tree;
					treeNum++;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
