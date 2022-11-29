using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

public class FileDataHandler
{
	string dataDirPath;
	string dataFileName;

	public FileDataHandler(string dataDirPath, string dataFileName)
	{
		this.dataDirPath = dataDirPath;
		this.dataFileName = dataFileName;
	}

	public GameData Load()
	{
		// use Path.Combine bcz different OS's have different path seperators
		string fullPath = Path.Combine(dataDirPath, dataFileName);
		GameData loadedData = null;
		if (File.Exists(fullPath))
		{
			try
			{
				// load the serialized data from the file
				string dataToLoad = File.ReadAllText(fullPath);

				Debug.Log(dataToLoad);

				// deserialize from JSON back into C# object
				loadedData = JsonConvert.DeserializeObject<GameData>(dataToLoad);
			}
			catch(Exception o)
			{
				Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + o);
			}
		}
		return loadedData;
	}

	public void Save(GameData data)
	{
		data = new GameData() { leaderBoard = TimerScript.scores, attempts = TimerScript.attempts };
		
		// use Path.Combine bcz different OS's have different path seperators
		string fullPath = Path.Combine(dataDirPath, dataFileName);
		Debug.Log(fullPath);
		try
		{
			// create directory path if it doesn't exist
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

			// serialize game data object into JSON
			string dataToSave = JsonConvert.SerializeObject(data);

			Debug.Log(dataToSave);

			// write the serialized data to the file
			File.WriteAllText(fullPath, dataToSave);
		}
		catch (Exception o)
		{
			Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + o);
		}
	}
}
