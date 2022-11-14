using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class LevelNavigator : MonoBehaviour
{
	string levelName, temp;
	int i;
	bool nameEnd;

	// Start is called before the first frame update
	void Start()
	{
		
	}
	
	public void GoToLevel()
	{
		TextMeshProUGUI levelID = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>();
		i = 0;
		nameEnd = false;
		levelName = "";
		temp = levelID.text;
		while (!nameEnd)
		{
			levelName = levelName + temp.Substring(i, 1);
			i++;
			if (temp.Substring(i, 1) == ".")
			{
				nameEnd = true;
			}
		}
		Debug.Log(levelName);
		LevelDesigner.levelName = levelName;
		SceneNavigator.PlayGame();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}


