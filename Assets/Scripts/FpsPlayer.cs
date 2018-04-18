using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FpsPlayer : MonoBehaviour {
	public float					maxDist = 7;
	private CharacterController		me;
	private MenuItem[]				items;
	private MenuItem				currentItem = null;

	void Start ()
	{
		me = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		items = FindObjectsOfType(typeof(MenuItem)) as MenuItem[];
	}
	
	void Update ()
	{
		GameObject		obj = RayLaunch();
		MenuItem		item = RayCheck(obj);

		HighlightItem(item);
		if (Input.GetKeyDown(KeyCode.E))
			RayClick(item, obj);
		if ((Input.GetKeyDown(KeyCode.Q)) && (item))
			item.ToggleHightlight();
		Move();
		transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
		transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X"));
		if ((!currentItem) && (item))
			item.ToggleHightlight();
		currentItem = item;
	}

	void Move()
	{
		Vector3	motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		motion.Normalize();
		motion = transform.rotation * motion;
		motion.y = 0;
		me.Move(motion * 0.3f);
	}

	GameObject	RayLaunch()
	{
		RaycastHit		hit;
		Ray				ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

		if (!Physics.Raycast(ray, out hit))
			return (null);
		if (hit.distance > maxDist)
			return (null);
		Debug.DrawLine(Camera.main.transform.position, hit.point, Color.cyan);
		return (hit.collider.gameObject);
	}

	// launch a ray from the center of the screen forward the player
	// can return a MenuItem or null if something else / nothing was hit
	MenuItem	RayCheck(GameObject obj)
	{
		if (!obj)
			return (null);
		return (obj.GetComponent<MenuItem>());
	}

	void RayClick(MenuItem item, GameObject obj)
	{
		MenuResetCfg		reset;

		if (item)
			item.OnClick();
		else if (!obj)
			Debug.Log("no object");
		else
		{
			reset = obj.GetComponent<MenuResetCfg>();
			if (reset)
				reset.OnClick();
		}
	}

	void HighlightItem(MenuItem item)
	{
		Color		color;

		foreach (MenuItem citem in items)
		{
			color = (citem == item) ? Color.green : Color.white;
			if (!citem.IsAvailable())
				color = Color.black;
			citem.GetComponent<MeshRenderer>().material.color = color;
		}
	}
}
