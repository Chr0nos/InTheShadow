using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clignoteur : MonoBehaviour {
	public float		interval;
	private Light		lamp;
	private float		now;
	private float		lampIntensity;

	void Start() {
		now = 0;
		lamp = GetComponent<Light>();
		lampIntensity = lamp.intensity;
	}

	void Update () {
		now += Time.deltaTime;
		if (now >= interval)
		{
			lamp.intensity = (lamp.intensity == 0) ? lampIntensity : 0;
			now = 0;
		}
	}
}
