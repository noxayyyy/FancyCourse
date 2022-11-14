using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
	float[] scores = TimerScript.scores;
	int i;
	public Text scoresText;
	string LoT;

	void Awake()
	{
		LoT = "";
		for (i = 0; i < 5; i++)
		{
			TimeSpan time = TimeSpan.FromSeconds(scores[i]);
			LoT = LoT + (i+1).ToString() + "." + " " + time.ToString(@"mm\:ss\:fff") + "\n";
		}
		if (SceneNavigator.afterRun)
		{
			TimeSpan time = TimeSpan.FromSeconds(scores[5]);
			LoT = "This Run: " + time.ToString(@"mm\:ss\:fff") + "\n\n" + LoT;
			SceneNavigator.afterRun = false;
		}
		scoresText.text = LoT;
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
