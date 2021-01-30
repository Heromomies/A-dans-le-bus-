using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

public class PickUpObject : MonoBehaviour
{
    
    public bool isPickable;
    public bool isBigObject;
    
    
    private void OnTriggerStay2D(Collider2D other)
    {
        //TODO ramassage d'objets + comparer si l'objet peut être ramasser 
        if (Input.GetKey(KeyCode.E) && isPickable)
        {
            GameManager.gm.objectsCatchByPlayer.Add(gameObject);
            GameManager.gm.CheckIfVictory();
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && isBigObject)
        {
            Camera.main.DOShakePosition(0.5f, 0.2f, 90, 2);
            Camera.main.DOShakeRotation(0.5f, .2f, 90, 2);
            BigObject._instance.Damage(1);
        }
    }
}
 