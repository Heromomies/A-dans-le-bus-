using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused;

	public GameObject pauseMenuUI1;
	public GameObject choseLevelPanel;
	
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

	public void LoadPanelLevel()
	{
		choseLevelPanel.SetActive(true);
		pauseMenuUI1.SetActive(false);
	}

	public void ChoseLevel(int levelNumber)
	{
		switch (levelNumber)
		{
			case 1:
				SceneManager.LoadScene(1);
				break;
			case 2:
				SceneManager.LoadScene(2);
				break;
			case 3:
				SceneManager.LoadScene(3);
				break;
		}
	}

	public void Return()
	{
		choseLevelPanel.SetActive(false);
		pauseMenuUI1.SetActive(true);
	}
}
