using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Vector3[]	finishEuler;
	public float		tolerance = 20;
	public bool			lock_x = false;
	public bool			lock_y = true;
	public bool			lock_z = true;
	public bool			lockTranslation = true;
	public Collider		finishTrigger = null;

	private bool		inFinishSpace = false;
	private bool		selected = false;
	private Rigidbody	rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		if (finishTrigger == null)
			inFinishSpace = true;
	}

	void Update () {
		if (!selected)
			return ;
		ShowAxisDebug();
		if ((Input.GetKey(KeyCode.LeftControl)) && (!lockTranslation))
			Translatage();
		else
			Rotationage((Input.GetKey(KeyCode.LeftShift) ? Space.World : Space.Self));
		if (Input.GetKeyDown(KeyCode.K))
			transform.rotation = Quaternion.Euler(finishEuler[0]);
		isFinished();
	}

	private void ShowAxisDebug()
	{
		if ((Input.GetKeyDown(KeyCode.P)) && (selected))
			Debug.Log(transform.eulerAngles);
		foreach (Vector3 euler in finishEuler)
			Debug.DrawLine(transform.position, Quaternion.Euler(euler) * Vector3.forward * 10, Color.red);
		Debug.DrawLine(transform.position, transform.position + transform.forward * 10, Color.green);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.Equals(finishTrigger))
			return ;
		inFinishSpace = true;
	}

	private void OnTriggerExit(Collider other)
	{
		if (!other.Equals(finishTrigger))
			return ;
		inFinishSpace = false;
	}

	public void SetActivate(bool state)
	{
		selected = state;
	}

	void Translatage()
	{
		Vector3 motion = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

		rb.velocity += motion;

	}

	void Rotationage(Space space)
	{
		Vector3		motion = Vector3.zero;

		if (Input.GetMouseButton(0))
		{
			if (!lock_z)
				motion.z = -Input.GetAxis("Mouse X");
		}
		else if (!lock_x)
			motion.y = Input.GetAxis("Mouse X");
		if (!lock_y)
			motion.x = Input.GetAxis("Mouse Y");
		if (space == Space.Self)
			motion = transform.rotation * motion;
		rb.AddTorque(motion);
		//transform.Rotate(motion, space);
	}

	// returns true if the object is in the good position to have the good shadow.
	public bool isFinished()
	{
		if  (!inFinishSpace)
			return (false);
		Vector3			rot = transform.eulerAngles;

		foreach (Vector3 euler in finishEuler)
		{
			if (!inRange(rot.x, euler.x))
				continue ;
			if (!inRange(rot.y, euler.y))
				continue ;
			if (!inRange(rot.z, euler.z))
				continue ;
		//	Debug.Log("Finish reached");
			return (true);
		}
		return (false);
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
