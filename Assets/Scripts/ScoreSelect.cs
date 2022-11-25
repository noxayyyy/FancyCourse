using UnityEngine;
using System.IO;

public class ScoreSelect : MonoBehaviour
{
	public LevelButtons levelButton;
	string levelDir, levelName;
	private void Awake()
	{
		levelDir = Directory.GetCurrentDirectory()+ "/Assets/Resources/Levels/";
		Directory.CreateDirectory(levelDir);
		ScoreCounter counter = gameObject.AddComponent<ScoreCounter>();
		var levelList = Directory.GetFiles(levelDir, "*.png", SearchOption.TopDirectoryOnly);
		foreach (string level in levelList)
		{
			levelName = Path.GetFileName(level);
			GenerateLevelButton(counter);
		}
	}
	
	void GenerateLevelButton(ScoreCounter counter)
	{
		Vector2 position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		Instantiate(levelButton.prefab, position, Quaternion.identity, gameObject.transform);
		counter.GenerateButtonText(levelName);
	}
}
