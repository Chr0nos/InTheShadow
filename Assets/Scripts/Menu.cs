using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
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
	}
}
