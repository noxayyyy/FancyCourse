using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
	public Text deathText;
	static public int deaths;

	// Start is called before the first frame update
	private void Start()
	{
		deathText.text = "Deaths: " + deaths.ToString();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Destroy(collision.gameObject);
			deaths++;
			SceneNavigator.ReloadScene();
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
