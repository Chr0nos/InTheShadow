﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	private Player[]	players;
	public string		nextLevelName;
	public GameObject	panel = null;

	private void Start()
	{
		players = FindObjectsOfType(typeof(Player)) as Player[];
		if (panel)
			panel.SetActive(false);
		ActivatePlayer(0);
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update ()
	{
		if (isGameFinished())
		{
		//	Debug.Log("Game finished.");
			Cursor.lockState = CursorLockMode.None;
			ActivatePlayer(-1);
			if (panel)
				panel.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
			ActivatePlayer(0);
		else if (Input.GetKeyDown(KeyCode.Alpha2))
			ActivatePlayer(1);
		else if (Input.GetKeyDown(KeyCode.Alpha3))
			ActivatePlayer(-1);
	}

	void ActivatePlayer(int id)
	{
		int		cid;

		cid = 0;
		foreach (Player p in players)
		{
			p.SetActivate(cid == id);
			cid++;
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

	public void NextLevel()
	{
		SceneManager.LoadScene(nextLevelName);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
