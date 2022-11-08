using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
	static public void ReloadScene()
	{
		SceneManager.LoadScene("Gameplay");
	}
	public void PlayGame()
	{
		Destroyer.deaths = 0;
		TimerScript.timerBegin();
		SceneManager.LoadScene("Gameplay");
	}

	static public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	static public void Leaderboard()
	{
		SceneManager.LoadScene("Leaderboard");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}//class
