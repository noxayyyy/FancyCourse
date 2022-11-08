using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
	static float currentTime = 0;
	static public float[] scores = new float[6];
	static public int attempts = 0;
	static bool timerStart = false;
	static bool timerStop = false;
	public Text currentTimeText;

	// Start is called before the first frame update
	void Start()
	{
		currentTimeText.text = currentTime.ToString();
	}
	
	public static void timerBegin()
	{
		timerStart = true;
		timerStop = false;
	}

	public static void timerEnd()
	{
		timerStart = false;
		timerStop = true;
		attempts++;
	}

	// Update is called once per frame
	void Update()
	{
		if (timerStart)
		{
			currentTime += Time.deltaTime;
			TimeSpan time = TimeSpan.FromSeconds(currentTime);
			currentTimeText.text = time.ToString(@"mm\:ss\:fff");
		}
		if (timerStop) 
		{
			scores[5] = currentTime;
			if (attempts == 1)
			{
				scores[0] = scores[5];
			}
			else if (attempts > 1 && attempts < 6)
			{
				scores[attempts - 1] = scores[5];
				Sort(attempts - 1);
			}
			else
			{
				Sort(5);
			}
			currentTime = 0;
		}
	}
	public static void Sort(int n)
	{
		int i;
		float temp;
		bool noSwap;
		do
		{
			noSwap = true;
			for(i = 0; i < n; i++)
			{
				if (scores[i] > scores[i + 1])
				{
					temp = scores[i+1];
					scores[i+1] = scores[i];
					scores[i] = temp;
					noSwap = false;
				}
			}
		}while(!noSwap);
	}
}
