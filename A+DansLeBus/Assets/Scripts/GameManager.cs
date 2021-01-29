using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timerEndLevel;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        timerEndLevel -= Time.deltaTime;
        if (timerEndLevel <=0)
        {
            //TODO le game over
            Debug.Log("GAME OVER");
        }
    }
}
