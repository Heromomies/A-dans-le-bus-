﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Water>() != null)
        {
            other.GetComponent<Water>().CreateElectricity();
        }
    }
}
