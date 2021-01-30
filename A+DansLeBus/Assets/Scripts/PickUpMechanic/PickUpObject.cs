using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PickUpObject : MonoBehaviour
{
    
    public bool isPickable = false;
    private void OnTriggerStay2D(Collider2D other)
    {
        //TODO ramassage d'objets + comparer si l'objet peut être ramasser 
        if (Input.GetKey(KeyCode.E) && isPickable)
        {
           
           
            GameManager.gm.CheckIfVictory();
            GameManager.gm.objectsCatchByPlayer.Add(gameObject);
            gameObject.SetActive(false);
        }
    }
    
}
