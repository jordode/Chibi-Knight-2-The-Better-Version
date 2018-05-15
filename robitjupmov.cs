using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robitjupmov : MonoBehaviour {

	Transform tf;
	private float speed;
	public GameObject player;
	public GameObject self;
	Transform checkl;
	Transform checkr;
	private int juptime;
	public LayerMask charmask;

	public bool left;
	public bool right;

	// Use this for initialization
	void Start () {

		tf = GetComponent<Transform> ();
		speed = 0.1f;
		juptime = 0;
		checkl = GameObject.Find ("left").GetComponent<Transform> ();
		checkr = GameObject.Find ("right").GetComponent<Transform> ();

	}
	void FixedUpdate () {

		right = Physics2D.OverlapCircle (checkr.position, 0.2f, charmask);
		left = Physics2D.OverlapCircle (checkl.position, 0.2f, charmask);
	}
	// Update is called once per frame
	void Update () {

		float playerx = player.transform.position.x;
		float selfx = self.transform.position.x;
		if (playerx > selfx+5.0f) {
			tf.Translate (speed, 0.0f, 0.0f);
		} else if (playerx < selfx-5.0f) {
			tf.Translate (-speed, 0.0f, 0.0f);
		} else {
			tf.Translate (0.0f, 0.0f, 0.0f);
		}
		if (right || left) {
			if (juptime == 0) {
				juptime = 15;
			}
		}

		if (juptime > 0) {
			juptime = juptime - 1;
			tf.Translate (0.0f, 0.5f, 0.0f);
		}
		{
			tf.rotation = Quaternion.AngleAxis (0.0f, Vector3.forward);
		}
	}
}

