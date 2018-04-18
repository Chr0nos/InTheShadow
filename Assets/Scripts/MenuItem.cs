using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour {
	public string			levelName;
	public string			levelMap;
	public bool				forceAvailable;
	public bool				quit = false;
	public MeshRenderer		mrender;
	public TextMesh			title;

	private bool			available;
	private bool			inCoroutine = false;
	private Rotationator	rotationator;
	private float			original;
	private float			delta = 0.025f;

	private void Start()
	{
		original = transform.localScale.x;
		available = PlayerPrefs.GetInt(levelMap, 0) == 1;
		rotationator = GetComponent<Rotationator>();
		rotationator.SetRotate(forceAvailable || IsAvailable());
		mrender = GetComponent<MeshRenderer>();
	}

	public bool IsAvailable()
	{
		if (forceAvailable)
			return (true);
		return (available);
	}

	public void SetAvailable(bool state)
	{
		PlayerPrefs.SetInt(levelMap, (state == true) ? 1 : 0);
		available = state;
		PlayerPrefs.Save();
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
		title.gameObject.SetActive(true);
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
		title.gameObject.SetActive(false);
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
