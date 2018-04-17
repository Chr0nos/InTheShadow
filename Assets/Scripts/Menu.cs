using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public struct slevel
{
	public string		title;
	public string		scene;
	public Button		testButton;
	public Button		stdButton;
	public bool			forceAvailable;
}

public class Menu : MonoBehaviour {
	public GameObject		mainPanel;
	public GameObject		testingPanel;
	public GameObject		stdPanel;
	
	public slevel[]			levels;

	private void Start()
	{
		UpdateButtons();
		MainMenu();
	}

	public void UpdateButtons()
	{
		foreach  (slevel lvl in levels)
		{
			Text		txt;

			if (lvl.stdButton)
			{
				// level is unavaialble
				if ((PlayerPrefs.GetInt(lvl.scene, 0) == 0) && (!lvl.forceAvailable))
				{
					Debug.Log("disable " + lvl.scene);
					lvl.stdButton.interactable = false;
					lvl.stdButton.enabled = false;
				}
				else
				{
					lvl.stdButton.interactable = true;
					lvl.stdButton.enabled = true;
				}
				txt = lvl.stdButton.GetComponentInChildren<Text>();
				txt.text = lvl.title;
			}
			else
				Debug.Log("warning: no std button for " + lvl.scene);
			txt = lvl.testButton.GetComponentInChildren<Text>();
			txt.text = lvl.title;
		}
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
		UpdateButtons();
		mainPanel.SetActive(false);
		stdPanel.SetActive(false);
		testingPanel.SetActive(true);
	}

	public void StdPanel()
	{
		stdPanel.SetActive(true);
		mainPanel.SetActive(false);
		testingPanel.SetActive(false);
	}

	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void Lvl00()
	{
		SceneManager.LoadScene("lvl00");
	}

	public void Lvl01()
	{
		SceneManager.LoadScene("lvl01");
	}

	public void Lvl02()
	{
		SceneManager.LoadScene("lvl02");
	}

	public void MainMenu()
	{
		testingPanel.SetActive(false);
		stdPanel.SetActive(false);
		mainPanel.SetActive(true);
	}

	public void ResetSave()
	{
		PlayerPrefs.SetInt("lvl00", 0);
		PlayerPrefs.SetInt("lvl01", 0);
		PlayerPrefs.SetInt("lvl02", 0);
	}
}
