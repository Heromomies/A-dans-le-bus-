using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
