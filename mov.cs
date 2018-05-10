
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour {

	Rigidbody2D myrb;
	Transform tf;
	float xspeed;
	float rotationZ;


	Transform groundcheck;
	public float jumpforce;
	public LayerMask charmask;
	private int juptime;

	public bool grounded;

	// Use this for initialization
	void Start () {
		myrb = this.GetComponent<Rigidbody2D> ();
		tf = GetComponent<Transform> ();
		groundcheck = GameObject.Find ("groundcheck").GetComponent<Transform> ();
		juptime = 0;
	}

	void FixedUpdate()
	{
		myrb.velocity = new Vector2 (xspeed, myrb.velocity.y);
		grounded = Physics2D.OverlapCircle (groundcheck.position, 0.5f, charmask);
	}

	// Update is called once per frame
	void Update () {

		{
			rotationZ = Mathf.Clamp (rotationZ, -45, 45);
		}

		if (Input.GetKey (KeyCode.A))
		{
			xspeed = -5;
		} else if (Input.GetKey (KeyCode.D))
		{
			xspeed = 5;
		} else
		{
			xspeed = 0;
		}

		if (Input.GetKey (KeyCode.Space)) {
			if (grounded) {
				juptime = 15;
			}
			}
		if (juptime > 0) {
			juptime = juptime - 1;
			tf.Translate (0.0f, 0.1f, 0.0f);

		}
		tf.rotation = Quaternion.AngleAxis (0.0f, Vector3.forward);
	

	}
	
		
}
