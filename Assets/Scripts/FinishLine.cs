using System.Collections;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Destroy(collision.gameObject);
			TimerScript.timerEnd();
			StartCoroutine(UponCollision());
		}
	}

	IEnumerator UponCollision()
	{
		PauseMenu.paused = true;
		yield return new WaitForSeconds(1);
		DataPersistenceManager.instance.SaveGame();
		PauseMenu.paused = false;
		SceneNavigator.AfterRunBoard();
	}
}
