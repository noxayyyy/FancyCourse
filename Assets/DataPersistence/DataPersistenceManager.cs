using System.Collections;
using System.IO;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
	[Header("File Storage Config")]
	public static string fileName;

	public GameData gameData;
	FileDataHandler dataHandler;

	public static DataPersistenceManager instance { get; private set;}

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Found morethan one DPM in the scene");
		}
		instance = this;
		dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
	}

	public void NewGame()
	{
		gameData = new GameData();
	}

	public void ResetScores()
	{
		StartCoroutine(DeleteSave());
	}

	IEnumerator DeleteSave()
	{
		string fullPath = Path.Combine(Application.persistentDataPath, fileName);
		File.Delete(fullPath);
		LoadGame();
		yield return new WaitForSeconds(1);
		SceneNavigator.ReloadScene();
	}

	public void SaveGame()
	{
		dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

		// save that data to a file using the data handler.
		dataHandler.Save(gameData);

		Debug.Log("Saved!");
	}

	public void LoadGame()
	{
		dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

		// load any saved data from a file using the handler.
		gameData = dataHandler.Load();

		// if no data can be loaded, give error.
		if(gameData == null)
		{
			Debug.Log("No data was found, making new game.");
			NewGame();
		}

		TimerScript.scores = gameData.leaderBoard;
		TimerScript.attempts = gameData.attempts;
		Debug.Log("Loaded!");
	}

	private void OnApplicationQuit()
	{
		SaveGame();
	}
}
