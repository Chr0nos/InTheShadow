using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleShow : MonoBehaviour {
	public TextMesh		title;
	public float		maxLenght = 7.0f;

	// Use this for initialization
	void Start () {
		title.gameObject.SetActive(false);
		StartCoroutine("CheckVisibility");
	}

	IEnumerator CheckVisibility()
	{
		while (true)
		{
			Ray			ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit	hit;

			if (!Physics.Raycast(ray, out hit))
				title.gameObject.SetActive(false);
			else if (hit.distance > maxLenght)
				title.gameObject.SetActive(false);
			else if (hit.collider.gameObject.Equals(this.gameObject))
			{
				title.gameObject.SetActive(true);
				title.transform.rotation = Camera.main.transform.rotation;
			}
			else
				title.gameObject.SetActive(false);
			yield return new WaitForSeconds(0.1f);
		}
	}
}