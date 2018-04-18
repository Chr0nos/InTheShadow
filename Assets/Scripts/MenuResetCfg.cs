using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuResetCfg : MonoBehaviour {
	private MenuItem[]		levels;
	public int				forcedValue = 0;

	void Start () {
		levels = FindObjectsOfType(typeof(MenuItem)) as MenuItem[];
	}
	
	public void OnClick()
	{
		Debug.Log("reseting configuration");
		foreach (MenuItem lvl in levels)
		{
			PlayerPrefs.SetInt(lvl.levelMap, forcedValue);
			if (!lvl.forceAvailable)
				lvl.SetReady(forcedValue == 1);
		}
		PlayerPrefs.Save();
	}
}
