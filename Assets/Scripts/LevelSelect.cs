using UnityEngine;
using System.IO;

public class LevelSelect : MonoBehaviour
{
	public LevelButtons levelButton;
	string levelDir, levelName;
	private void Awake()
	{
		levelDir = Directory.GetCurrentDirectory()+ "/Assets/Resources/Levels/";
		Directory.CreateDirectory(levelDir);
		LevelCounter counter = gameObject.AddComponent<LevelCounter>();
		var levelList = Directory.GetFiles(levelDir, "*.png", SearchOption.TopDirectoryOnly);
		foreach (string level in levelList)
		{
			levelName = Path.GetFileName(level);
			GenerateLevelButton(counter);
		}
	}
	
	void GenerateLevelButton(LevelCounter counter)
	{
		Vector2 position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		Instantiate(levelButton.prefab, position, Quaternion.identity, gameObject.transform);
		counter.GenerateButtonText(levelName);
	}
}
