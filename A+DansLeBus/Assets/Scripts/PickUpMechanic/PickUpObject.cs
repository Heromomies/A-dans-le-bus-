using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public List<GameObject> objectsPickUp = new List<GameObject>();
    private void OnTriggerStay2D(Collider2D other)
    {
        //TODO ramassage d'objets + comparer si l'objet peut être ramasser 
        if (Input.GetKey(KeyCode.E))
        {
            objectsPickUp.Add(other.gameObject);
            other.gameObject.SetActive(false);
            GameManager.gm.CheckIfVictory(objectsPickUp.Count);
        }
    }
    
}
