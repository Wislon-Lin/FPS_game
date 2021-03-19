using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FPS_move : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKey (KeyCode.A))
			transform.position -= transform.right * 0.05f;
		if (Input.GetKey (KeyCode.D))
			transform.position += transform.right * 0.05f;
		if (Input.GetKey (KeyCode.W))
			transform.position += transform.up * 0.05f;
		if (Input.GetKey (KeyCode.S))
			transform.position -= transform.up * 0.05f;
		if (Input.GetKey (KeyCode.R))
			transform.position += transform.forward * 0.1f;
		if (Input.GetKey (KeyCode.F))
			transform.position -= transform.forward * 0.1f;
		if (Input.GetKey (KeyCode.RightArrow))
			transform.localEulerAngles += new Vector3 (0,0.3f,0);
		if (Input.GetKey (KeyCode.LeftArrow))
			transform.localEulerAngles -= new Vector3 (0,0.3f,0); 
	}
}
