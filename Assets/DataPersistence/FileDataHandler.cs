using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using TMPro;
using Newtonsoft.Json;
using Unity.VisualScripting;

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
				string dataToLoad;
				using(FileStream stream = new FileStream(fullPath, FileMode.Open))
				{
					using(StreamReader reader = new StreamReader(stream))
					{
						dataToLoad = reader.ReadToEnd();
					}
				}

				// deserialize from JSON back into C# object
				loadedData = JsonConvert.DeserializeObject<GameData>(dataToLoad);
			}
			catch(Exception o)
			{
				Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + o);
			}
		}
		return loadedData;
	}

	public void Save(GameData data)
	{
		// use Path.Combine bcz different OS's have different path seperators
		string fullPath = Path.Combine(dataDirPath, dataFileName);
		try
		{
			// create directory path if it doesn't exist
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

			// serialize game data object into JSON
			string dataToSave = JsonConvert.SerializeObject(data);

			// write the serialized data to the file
			using(FileStream stream = new FileStream(fullPath, FileMode.Create))
			{
				using (StreamWriter writer = new StreamWriter(stream))
				{
					writer.Write(dataToSave);
				}
			}
		}
		catch (Exception o)
		{
			Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + o);
		}
	}
}
