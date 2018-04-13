﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Player[]		players;

	void Update () {
		if (isGameFinished())
		{
			Debug.Log("Game finished.");
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