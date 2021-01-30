using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    private List<GameObject> _waterObject = new List<GameObject>();
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Water>() != null)
        {
            other.GetComponent<Water>().CreateElectricity();
            gameObject.SetActive(false);
        }
    }
}
