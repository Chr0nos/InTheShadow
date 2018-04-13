using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public Player[]		players;
	public string		nextLevelName;
	public GameObject	panel;

	private void Start()
	{
		panel.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		if (isGameFinished())
		{
			Debug.Log("Game finished.");
			Cursor.lockState = CursorLockMode.None;
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
		return (true);
	}
}
