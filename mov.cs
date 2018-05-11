
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour {

	Rigidbody2D myrb;
	Transform tf;
	float xspeed;
	float rotationZ;


	Transform groundcheck;
	Transform groundcheckr;
	Transform groundcheckl;
	public float jumpforce;
	public LayerMask charmask;
	private int juptime;

	public bool grounded;
	public bool groundedl;
	public bool groundedr;

	// Use this for initialization
	void Start () {
		myrb = this.GetComponent<Rigidbody2D> ();
		tf = GetComponent<Transform> ();
		groundcheck = GameObject.Find ("groundcheck").GetComponent<Transform> ();
		groundcheckl = GameObject.Find ("groundcheck left").GetComponent<Transform> ();
		groundcheckr = GameObject.Find ("groundcheck right").GetComponent<Transform> ();

		juptime = 0;
	}

	void FixedUpdate()
	{
		myrb.velocity = new Vector2 (xspeed, myrb.velocity.y);
		grounded = Physics2D.OverlapCircle (groundcheck.position, 0.5f, charmask);
		groundedl = Physics2D.OverlapCircle (groundcheckl.position, 0.5f, charmask);
		groundedr = Physics2D.OverlapCircle (groundcheckr.position, 0.5f, charmask);

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

		if (Input.GetKeyDown (KeyCode.Space) && juptime == 0) {
			if (grounded || groundedr || groundedl) {
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
