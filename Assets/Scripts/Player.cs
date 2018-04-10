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
		Vector3 motion = new Vector3(0, Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		motion.Normalize();
		motion.x *= speed.x;
		motion.y *= speed.y;
		motion.z *= speed.z;
		transform.Rotate(motion);
		if (isFinished())
			finished = true;
	}

	bool isFinished()
	{
		Vector3		rot = transform.rotation.eulerAngles;

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
