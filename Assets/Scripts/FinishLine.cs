using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			TimerScript.timerEnd();
			StartCoroutine(UponCollision());
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	IEnumerator UponCollision()
	{
		PauseMenu.paused = true;
		yield return new WaitForSeconds(5);
		DataPersistenceManager.instance.SaveGame();
		PauseMenu.paused = false;
		SceneNavigator.AfterRunBoard();
	}
}
