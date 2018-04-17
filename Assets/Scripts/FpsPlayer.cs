using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsPlayer : MonoBehaviour {
	private CharacterController		me;

	// Use this for initialization
	void Start () {
		me = GetComponent<CharacterController>();		
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
		transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X"));
	}

	void Move()
	{
		Vector3	motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		motion.Normalize();
		motion = transform.rotation * motion;
		motion.y = 0;
		me.Move(motion * 0.3f);
	}
}
