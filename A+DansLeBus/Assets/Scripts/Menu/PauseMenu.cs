using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused;

	public GameObject pauseMenuUI1;
	//public GameObject choseLevelPanel;

	public GameObject menuOptions;
	void Update() // Appuyer sur la touche Echap pour : 
	{
		if (Input.GetKeyDown(KeyCode.Escape))

			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
	}
	public void Resume() // Remet le jeu 
	{
		pauseMenuUI1.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	public void Restart() // Remet le jeu 
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}
	void Pause() // Freeze le temps et le jeu
	{
		pauseMenuUI1.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void LoadMenu() // retourne au Menu
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}

	public void Options()
	{
		menuOptions.SetActive(true);
	}
}
