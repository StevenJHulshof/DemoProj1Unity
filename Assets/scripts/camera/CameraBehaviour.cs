using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	public float movementSpeed = 10.0f;
	public float zoomSpeed = 5.0f;
	public float horizontalSensitivity = 2.0f;
	public float verticalSensitivity = 2.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey("q"))
			this.transform.localEulerAngles += new Vector3 (0.0f, 50.0f * Time.deltaTime, 0.0f);
		if(Input.GetKey("e"))
			this.transform.localEulerAngles += new Vector3 (0.0f, -50.0f * Time.deltaTime, 0.0f);
//		if(Input.GetKey("z"))
//			this.transform.localPosition += new Vector3(zoomSpeed * Time.fixedDeltaTime;
//		if(Input.GetKey("x"))
//			this.transform.forward += -zoomSpeed * Time.fixedDeltaTime;


//		if (Input.GetMouseButton (1) )
//		{
//			transform.Rotate (0.0f, Input.GetAxis ("Mouse X") * horizontalSensitivity * -1, 0.0f);	
//			rotationX += Input.GetAxis ("Mouse Y") * verticalSensitivity;
//
//			float rotationY = transform.localEulerAngles.y;

//		}

		if (Input.GetKey ("d"))
			this.transform.position += new Vector3(movementSpeed * Time.fixedDeltaTime, 0, 0);		
		if (Input.GetKey ("a"))
			this.transform.position -= new Vector3(movementSpeed * Time.fixedDeltaTime, 0, 0);
		if (Input.GetKey ("w"))
			this.transform.position += new Vector3(0, 0, movementSpeed * Time.fixedDeltaTime);
		if (Input.GetKey ("s"))
			this.transform.position -= new Vector3(0, 0, movementSpeed * Time.fixedDeltaTime);
	}
}
