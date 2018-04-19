using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotationator : MonoBehaviour {
	public bool				rotate = true;
	public bool				rotateY = false;
	public Space			space = Space.Self;

	private void Start()
	{
		StartCoroutine("RotateMe");
	}

	IEnumerator RotateMe()
	{
		while (rotate)
		{
			transform.Rotate(Vector3.up * Time.deltaTime * 60, space);
			if (rotateY)
				transform.Rotate(Vector3.right * Time.deltaTime * 60);
			yield return null;
		}
	}

	public void SetRotate(bool state)
	{
		if ((state) && (!rotate))
		{
			rotate = true;
			StartCoroutine("RotateMe");
		}
		rotate = state;
	}
}
