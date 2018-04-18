using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItem : MonoBehaviour {
	public string	levelName;
	public string	levelMap;
	public bool		forceAvailable; 
	public bool		quit = false;
	private bool	ready;
	private bool	inCoroutine = false;

	private void Start()
	{
		if (forceAvailable)
			ready = true;
		else
			ready = IsAvailable();
	}

	private void Update()
	{
		if (ready)
			transform.Rotate(Vector3.up, Space.World);
	}

	public bool IsAvailable()
	{
		if (forceAvailable)
			return (true);
		return (PlayerPrefs.GetInt(levelMap, 0) == 1);
	}

	public void OnClick()
	{
		Debug.Log("Click trigger " + name);
		if ((!forceAvailable) && (!IsAvailable()))
			return ;
		if (quit)
			Application.Quit();
		else
		{
			Debug.Log("Loading " + levelMap);
			SceneManager.LoadScene(levelMap);
		}
	}

	// just wanted to try coroutines
	// this thing take the original scale then max it by 50% then lower it by 50%
	// and returns to the original size.
	IEnumerator Highlight()
	{
		float			original = transform.localScale.x;
		float			max = original * 1.5f;
		float			min = original * 0.5f;
		float			delta = 0.025f;

		inCoroutine = true;
		for (float x = transform.localScale.x; x < max; x += delta)
		{
			transform.localScale = new Vector3(x, x, x);
			yield return null;
		}
		for (float x = max; x > min; x -= delta)
		{
			transform.localScale = new Vector3(x, x, x);
			yield return null;
		}
		for (float x = min; x < original; x += delta)
		{
			transform.localScale = new Vector3(x, x, x);
			yield return null;
		}
		inCoroutine = false;
	}

	public void ToggleHightlight()
	{
		if (!inCoroutine)
			StartCoroutine("Highlight");
	}
}
