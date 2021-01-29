using System;
using System.Collections;
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
    #region singleton
    public static GameManager gm;


    public List<GameObject> allGameObjects;
    public List<GameObject> objectsToCatch;

    public Transform[] spawnPoints;
    public int numbersObjects;
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
     
    }

    // Update is called once per frame
    void Update()
    {
        timerEndLevelSecond -= Time.deltaTime;
        timerTxt.text = timerEndLevelMinute + " : " + _txtSecond;
        if (timerEndLevelSecond <=0 && timerEndLevelMinute<=0)
        {
            timerEndLevelSecond = 0;
            //TODO le game over
            Debug.Log("GAME OVER");
        }        
        else if (timerEndLevelSecond<= 0 && timerEndLevelMinute >0)
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
}
