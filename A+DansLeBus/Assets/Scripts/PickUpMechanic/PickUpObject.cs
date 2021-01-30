using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

public class PickUpObject : MonoBehaviour
{
    
    public bool isPickable;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetMouseButtonDown(0) && isPickable)
        {
            GameManager.gm.objectsCatchByPlayer.Add(gameObject);
            GameManager.gm.CheckIfVictory();
            gameObject.SetActive(false);
        }
    }
}
 