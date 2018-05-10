using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robitmov : MonoBehaviour {

	Transform tf;
	private float speed;
	public GameObject player;

	// Use this for initialization
	void Start () {

		tf = GetComponent<Transform> ();
		speed = 0.04f;
		
	}
	
	// Update is called once per frame
	void Update () {

		float playerx = player.transform.position.x;
		float selfx = Input.GetAxis ("Horizontal");
		if (playerx > selfx) {
			tf.Translate (speed, 0.0f, 0.0f);
		} else if (playerx < selfx) {
			tf.Translate (-speed, 0.0f, 0.0f);
		}
		{
			tf.rotation = Quaternion.AngleAxis (0.0f, Vector3.forward);
		}
	}
}
	
