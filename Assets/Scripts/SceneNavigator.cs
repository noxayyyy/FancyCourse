using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
	public static bool afterRun;

	static public void ReloadScene()
	{
		string sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == "Gameplay")
		{
			TimerScript.timerBegin();
		}
		SceneManager.LoadScene(sceneName);
	}

	public static void PlayGame()
	{
		Destroyer.deaths = 0;
		TimerScript.timerBegin();
		SceneManager.LoadScene("Gameplay");
	}

	public void NewGame()
	{
		DataPersistenceManager.instance.NewGame();
	}

	public void LoadGame()
	{
		DataPersistenceManager.instance.LoadGame();
	}

	public void SaveGame()
	{
		DataPersistenceManager.instance.SaveGame();
	}

	static public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public static void ScoreSelect()
	{
		SceneManager.LoadScene("ScoreSelect");
	}

	static public void Leaderboard()
	{
		SceneManager.LoadScene("Leaderboard");
	}

	static public void AfterRunBoard()
	{
		afterRun = true;
		SceneManager.LoadScene("Leaderboard");
	}

	public void LevelSelect()
	{
		SceneManager.LoadScene("LevelSelect");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public static IEnumerator WaitRoutine(int seconds)
	{
		yield return new WaitForSeconds(seconds);
	}
}//class
