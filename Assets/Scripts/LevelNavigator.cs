using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class LevelNavigator : MonoBehaviour
{
	string levelName, temp;
	int i;
	bool nameEnd;
	
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
		DataPersistenceManager.fileName = levelName;
		DataPersistenceManager.instance.LoadGame();
		SceneNavigator.PlayGame();
	}
}


