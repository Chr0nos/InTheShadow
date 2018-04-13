using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Vector3		finishEuler;
	public float		tolerance = 3;
	public bool			lock_x = false;
	public bool			lock_y = true;
	public bool			lock_z = true;
	private bool		finished = false;

	[Space]
	public float		smoothTime = 0.1f;
	public float		maxSpeed = 7;

	public bool			constraintFoldout = false;

	Vector3				rotationVelocity;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		if (finished)
			return ;
		Debug.Log(transform.eulerAngles);
		if (Input.GetKey(KeyCode.LeftControl))
			Translatage();
		else
			Rotationage();
		if (isFinished())
			finished = true;
		Debug.DrawLine(transform.position, Quaternion.Euler(finishEuler) * Vector3.forward * 10, Color.red);
		Debug.DrawLine(transform.position, transform.position + transform.forward * 10, Color.green);
	}

	void Translatage()
	{
		Vector3 motion = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
		transform.position += motion;
	}

	void Rotationage()
	{
		if (!lock_x)
			transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
		if (!lock_y)
			transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y"));
	}

	// returns true if the object is in the good position to have the good shadow.
	public bool isFinished()
	{
		if (finished)
			return (true);
		// Vector3		rot = transform.forward;
		Vector3			rot = transform.eulerAngles;

		if (!inRange(rot.x, finishEuler.x))
			return (false);
		if (!inRange(rot.y, finishEuler.y))
			return (false);
		if (!inRange(rot.z, finishEuler.z))
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
