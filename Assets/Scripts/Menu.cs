using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public struct slevels
{
	public string	title;
	public string	scene;
	public Button	button;
}

public class Menu : MonoBehaviour {
	public GameObject		mainPanel;
	public GameObject		testingPanel;
	[System.Serializable]
	public slevels[]		levels;

	private void Start()
	{
		MainMenu();
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Standard()
	{
		SceneManager.LoadScene("lvl00");
	}

	public void Testing()
	{
		mainPanel.SetActive(false);
		testingPanel.SetActive(true);
	}

	public void Lvl00()
	{
		SceneManager.LoadScene("lvl00");
	}

	public void Lvl01()
	{
		SceneManager.LoadScene("lvl01");
	}

	public void MainMenu()
	{
		testingPanel.SetActive(false);
		mainPanel.SetActive(true);
	}
}
