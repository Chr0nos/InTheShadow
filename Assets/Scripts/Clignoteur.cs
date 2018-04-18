using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clignoteur : MonoBehaviour {
	public float		interval;
	public float		coef;
	private Light		lamp;
	private float		lampIntensity;
	private float		pos;

	void Start() {
		pos = 0;
		lamp = GetComponent<Light>();
		lampIntensity = lamp.intensity;
	}

	void Update ()
	{
		SinonusoLight();
	}

	void SinonusoLight()
	{
		float		si;

		pos += coef;
		si = Mathf.Sin(pos);
		lamp.intensity = si * lampIntensity;
	}
}
