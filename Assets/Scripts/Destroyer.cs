using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
	public Text deathText;
	static public int deaths;

	private void Update()
	{
		deathText.text = "Deaths: " + deaths.ToString();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			deaths++;
			Debug.Log(deaths);
			SceneNavigator.ReloadScene();
		}
	}
}
