using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Vector3		finishRotation;
	public float		tolerance = 3;
	public Vector3		speed = new Vector3(2, 2, 2);
	private bool		finished = false;

	void Update () {
		if (finished)
			return ;
		if (Input.GetKey(KeyCode.LeftControl))
			Translatage();
		else
			Rotationage();
		if (isFinished())
			finished = true;
		Debug.DrawLine(transform.position, transform.position + finishRotation * 10, Color.red);
		Debug.DrawLine(transform.position, transform.position + transform.forward * 10, Color.green);
	}

	void Translatage()
	{
		Vector3 motion = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
		transform.position += motion;
	}

	void Rotationage()
	{
		Vector3 localSpeed = transform.rotation * speed;
		Vector3 motion = new Vector3(0, Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		motion = transform.rotation * motion;
		motion.Normalize();
		motion.x *= localSpeed.x;
		motion.y *= localSpeed.y;
		motion.z *= localSpeed.z;
		transform.Rotate(motion);
	}

	// returns true if the object is in the good position to have the good shadow.
	public bool isFinished()
	{
		if (finished)
			return (true);
		Vector3		rot = transform.forward;

		if (!inRange(rot.x, finishRotation.x))
			return (false);
		if (!inRange(rot.y, finishRotation.y))
			return (false);
		if (!inRange(rot.z, finishRotation.z))
			return (false);
		Debug.Log("finish reached");
		return (true);
	}

	bool inRange(float x, float finish)
	{
		if (x > (finish + tolerance))
			return (false);
		if (x < (finish - tolerance))
			return (false);
		return (true);
	}
}
