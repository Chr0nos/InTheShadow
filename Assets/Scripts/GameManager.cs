using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public string		nextLevelName;
	public GameObject	panel = null;
	public AudioClip	finishSound;

	private Player[]	players;
	private bool		finished = false;

	private void Start()
	{
		players = FindObjectsOfType(typeof(Player)) as Player[];
		if (panel)
			panel.SetActive(false);
		ActivatePlayer(0);
		SetLockMode(true);
	}

	void SetLockMode(bool state)
	{
		if (state)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	void Update ()
	{
		if (isGameFinished())
			FinishLevel();
		if (Input.GetKeyDown(KeyCode.Alpha1))
			ActivatePlayer(0);
		else if (Input.GetKeyDown(KeyCode.Alpha2))
			ActivatePlayer(1);
		else if (Input.GetKeyDown(KeyCode.Alpha3))
			ActivatePlayer(-1);
		if (Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene("LiveMenu");
	}

	private void PlayFinishSound()
	{
		AudioSource		sound;

		if (!finishSound)
			return ;
		sound = Camera.main.GetComponent<AudioSource>();
		sound.clip = finishSound;
		sound.Play();
	}

	private void FinishLevel()
	{
		if (finished)
			return ;
		PlayFinishSound();
		Debug.Log("Level finished.");
		ActivatePlayer(-1);
		if (panel)
			panel.SetActive(true);
		SetLockMode(false);
		finished = true;
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
