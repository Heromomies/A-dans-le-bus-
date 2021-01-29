using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public List<GameObject> objectsPickUp = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO ramassage d'objets + comparer si l'objet peut être ramasser 
        
        objectsPickUp.Add(other.gameObject);
        other.gameObject.SetActive(false);
        GameManager.gm.CheckIfVictory(objectsPickUp.Count);
    }
    
}
