using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
	public void GenerateButtonText(string levelName)
	{
		GameObject buttonText = GameObject.Find("LevelButton(Clone)");
		TextMeshProUGUI levelCounter = buttonText.GetComponentInChildren<TextMeshProUGUI>();
		levelCounter.text = levelName;
		buttonText.name = levelName;
	}
}
