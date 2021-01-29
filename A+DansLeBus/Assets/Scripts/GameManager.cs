using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    public float timerEndLevelSecond;
    public int timerEndLevelMinute;


    public TextMeshProUGUI timerTxt;
    private string _txtSecond;

    public List<GameObject> allGameObjects;
    public List<GameObject> objectsToCatch;

    public List<Transform> spawnPoints;
    public int numbersObjectsToFind;

    #region singleton

    public static GameManager gm;


    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numbersObjectsToFind; i++)
        {
            int randomObjectIndex = Random.Range(0, allGameObjects.Count);
            objectsToCatch.Add(allGameObjects[randomObjectIndex]);
            allGameObjects.RemoveAt(randomObjectIndex);
        }

        for (int i = 0; i < objectsToCatch.Count; i++)
        {
            int randomPos = Random.Range(0, spawnPoints.Count);
            objectsToCatch[i].transform.position = spawnPoints[randomPos].position;
            spawnPoints.RemoveAt(randomPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerEndLevelSecond -= Time.deltaTime;
        timerTxt.text = timerEndLevelMinute + " : " + _txtSecond;
        if (timerEndLevelSecond <= 0 && timerEndLevelMinute <= 0)
        {
            timerEndLevelSecond = 0;
            //TODO le game over
            Debug.Log("GAME OVER");
        }
        else if (timerEndLevelSecond <= 0 && timerEndLevelMinute > 0)
        {
            timerEndLevelMinute--;
            timerEndLevelSecond = 59;
        }

        if (timerEndLevelSecond <= 10)
        {
            _txtSecond = "0" + timerEndLevelSecond.ToString("F0");
        }
        else
        {
            _txtSecond = timerEndLevelSecond.ToString("F0");
        }
    }

    public void CheckIfVictory(List<GameObject> gameObjectsGetByPlayer)
    {
        if (gameObjectsGetByPlayer.Count == objectsToCatch.Count)
        {
            //TODO C'est la win
            Debug.Log("VICTOIRE");
        }
    }
}