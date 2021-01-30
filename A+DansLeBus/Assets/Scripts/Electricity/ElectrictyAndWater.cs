using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrictyAndWater : MonoBehaviour
{
    public float durationStun;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine(WaitBeforeMove());
        }
    }

    IEnumerator WaitBeforeMove()
    {
        yield return new WaitForSeconds(durationStun);
        PlayerMovement._instance.enabled = true;
    }
}
