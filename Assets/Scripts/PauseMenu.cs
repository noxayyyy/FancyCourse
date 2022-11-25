using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	[SerializeField]
	GameObject pauseMenu, continueButton, retryButton, exitButton;
	public static bool paused;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("escape"))
		{
			paused = !paused;
			pauseGame();
		}
	}

	public void pauseGame()
	{
		if (paused)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
		pauseMenu.SetActive(!pauseMenu.activeSelf);
		continueButton.SetActive(!continueButton.activeSelf);
		retryButton.SetActive(!retryButton.activeSelf);
		exitButton.SetActive(!exitButton.activeSelf);
	}

	public void resumeGame()
	{
		pauseMenu.SetActive(false);
		continueButton.SetActive(false);
		retryButton.SetActive(false);
		exitButton.SetActive(false);
		Time.timeScale = 1f;
	}

	public void retryGame()
	{
		SceneNavigator.ReloadScene();
		Destroyer.deaths = 0;
		Time.timeScale = 1f;
	}

	public void quitGame()
	{
		TimerScript.timerStart = false;
		Time.timeScale = 1f;
		SceneNavigator.MainMenu();
	}
}
