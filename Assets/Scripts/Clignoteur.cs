using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clignoteur : MonoBehaviour {
	public float		coef;
	private Light		lamp;

	void Start() {
		lamp = GetComponent<Light>();
		StartCoroutine("SinonusoLight");
	}

	IEnumerator SinonusoLight()
	{
		float		pos;

		pos = 0;
		while (true)
		{
			pos += coef;
			lamp.intensity = Mathf.Sin(pos * Time.deltaTime * 60) * 0.5f + 0.5f;
			if (pos > 6.28f)
				pos -= 6.28f;
			yield return null;
		}
	}
}
