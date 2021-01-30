using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PickUpObject : MonoBehaviour
{
    
    public bool isPickable;
    private void OnTriggerStay2D(Collider2D other)
    {
        //TODO ramassage d'objets + comparer si l'objet peut être ramasser 
        if (Input.GetKey(KeyCode.E) && isPickable)
        {
            GameManager.gm.objectsCatchByPlayer.Add(gameObject);
            GameManager.gm.CheckIfVictory();
            gameObject.SetActive(false);
        }
    }
    
}
 