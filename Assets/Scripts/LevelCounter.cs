using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCounter : MonoBehaviour
{
	// Start is called before the first frame update
	public void GenerateButtonText(string levelName)
	{
		GameObject buttonText = GameObject.Find("LevelButton(Clone)");
		TextMeshProUGUI levelCounter = buttonText.GetComponentInChildren<TextMeshProUGUI>();
		levelCounter.text = levelName;
		buttonText.name = levelName;
	}
}
