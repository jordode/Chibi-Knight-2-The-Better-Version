using UnityEngine;
using System.Collections;

public class rotatur : MonoBehaviour {

	void Update () 
	{
		if (Input.GetKey (KeyCode.Space))
			transform.Rotate (new Vector3 (0, 0, -9));
			
	}
}
