using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ScoreNav : MonoBehaviour
{
	string boardName, temp;
	int i;
	bool nameEnd;

	// Start is called before the first frame update
	void Start()
	{
		
	}
	
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

	// Update is called once per frame
	void Update()
	{
		
	}
}


