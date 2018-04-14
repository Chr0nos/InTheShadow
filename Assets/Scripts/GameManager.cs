using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public Player[]		players;
	public string		nextLevelName;
	public GameObject	panel = null;

	private void Start()
	{
		if (panel)
			panel.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		if (isGameFinished())
		{
			Debug.Log("Game finished.");
			Cursor.lockState = CursorLockMode.None;
			if (panel)
				panel.SetActive(true);
		}
	}

	bool isGameFinished()
	{
		foreach (Player p in players)
		{
			if (!p.isFinished())
				return (false);
		}
		PlayerPrefs.SetInt(nextLevelName, 1);
		PlayerPrefs.Save();
		return (true);
	}
}
