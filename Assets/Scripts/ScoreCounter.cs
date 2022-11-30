using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
	public void GenerateButtonText(string levelName)
	{
		GameObject buttonText = GameObject.Find("ScoreButton(Clone)");
		TextMeshProUGUI levelCounter = buttonText.GetComponentInChildren<TextMeshProUGUI>();
		levelCounter.text = levelName;
		buttonText.name = levelName;
	}
}
