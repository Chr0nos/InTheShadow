using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItem : MonoBehaviour {
	public string			levelName;
	public string			levelMap;
	public bool				forceAvailable; 
	public bool				quit = false;
	public MeshRenderer		mrender;

	private bool			inCoroutine = false;
	private Rotationator	rotationator;
	private float			original;
	private float			delta = 0.025f;

	private void Start()
	{
		original = transform.localScale.x;
		rotationator = GetComponent<Rotationator>();
		rotationator.SetRotate(forceAvailable || IsAvailable());
		mrender = GetComponent<MeshRenderer>();
	}

	public bool IsAvailable()
	{
		if (forceAvailable)
			return (true);
		return (PlayerPrefs.GetInt(levelMap, 0) == 1);
	}

	public void OnClick()
	{
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

	IEnumerator Selected()
	{
		float		max = original * 1.5f;
	
		inCoroutine = true;
		for (float c = original; c < max && inCoroutine; c += delta)
		{
			transform.localScale = new Vector3(c, c, c);
			yield return null;
		}
		inCoroutine = false;
	}

	IEnumerator UnSelected()
	{
		inCoroutine = true;
		for (float c = transform.localScale.x; c > original && inCoroutine; c -= delta)
		{
			transform.localScale = new Vector3(c, c, c);
			yield return null;
		}
		inCoroutine = false;
	}

	public void SetSelectedState(bool state)
	{
		inCoroutine = false;
		if (state)
			StartCoroutine("Selected");
		else
			StartCoroutine("UnSelected");
	}

	public void SetReady(bool state)
	{
		rotationator.SetRotate(state);
	}
}
