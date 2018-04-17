using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRotate : MonoBehaviour {
	private void Update()
	{
		transform.Rotate(Vector3.up, Space.World);
	}
}
