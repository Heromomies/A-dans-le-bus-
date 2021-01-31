﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer_Cinématique : MonoBehaviour
{
    public TextMeshProUGUI textMeshProGui;


    private void Start()
    {
        Time.timeScale = 1;
    }

    public void TextAppear()
    {
        textMeshProGui.gameObject.SetActive(true);
    }
    
    public void LoadSceneMain()
    {
       
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void PlayRonflement()
    {
        SoundManager.instance.Play("Ronflement");
    }

    public void PlayBaillement()
    {
        SoundManager.instance.Play("Baillement");
    }

    public void PlaySurprise()
    {
        SoundManager.instance.Play("Surprise");
    }

    public void PlayKlaxon()
    {
        SoundManager.instance.Play("Klaxon");
    }

    public void PlayKlaxon2()
    {
        SoundManager.instance.Play("Klaxon");
    }
        
}
