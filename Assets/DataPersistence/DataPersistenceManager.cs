using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
	[Header("File Storage Config")]
	[SerializeField] string fileName;

	public GameData gameData;
	List<IDataPersistence> dataPersistenceObjects;
	FileDataHandler dataHandler;

	public static DataPersistenceManager instance { get; private set;}

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Found morethan one DPM in the scene");
		}
		instance = this;
	}

	private void Start()
	{
		this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
		this.dataPersistenceObjects = FindAllDataPersistenceObjects();
		LoadGame();
	}

	public void NewGame()
	{
		this.gameData = new GameData();
	}

	public void SaveGame()
	{
		// pass the data to other scripts to update it.
		foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
			dataPersistenceObj.SaveData(gameData);

		// save that data to a file using the data handler.
		dataHandler.Save(gameData);

		Debug.Log("Saved!");
	}

	public void LoadGame()
	{
		// load any saved data from a file using the handler.
		this.gameData = dataHandler.Load();

		// if no data can be loaded, give error.
		if(this.gameData == null)
		{
			Debug.LogError("No data was found, making new game.");
			NewGame();
		}
		
		// push the loaded to all oter scripts that need it.
		foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
			dataPersistenceObj.LoadData(gameData);
	}

	private void OnApplicationQuit()
	{
		SaveGame();
	}

	private List<IDataPersistence> FindAllDataPersistenceObjects()
	{
		IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
			.OfType<IDataPersistence>();
		return new List<IDataPersistence>(dataPersistenceObjects);
	}
}
