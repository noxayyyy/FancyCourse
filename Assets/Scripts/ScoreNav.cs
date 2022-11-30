using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ScoreNav : MonoBehaviour
{
	string boardName, temp;
	int i;
	bool nameEnd;
	
	public void GoToLB()
	{
		TextMeshProUGUI levelID = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>();
		i = 0;
		nameEnd = false;
		boardName = "";
		temp = levelID.text;
		while (!nameEnd)
		{
			boardName = boardName + temp.Substring(i, 1);
			i++;
			if (temp.Substring(i, 1) == ".")
			{
				nameEnd = true;
			}
		}
		Debug.Log(boardName);
		DataPersistenceManager.fileName = boardName;
		DataPersistenceManager.instance.LoadGame();
		SceneNavigator.Leaderboard();
	}
}


