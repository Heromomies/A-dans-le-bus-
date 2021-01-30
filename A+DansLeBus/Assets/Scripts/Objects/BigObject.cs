using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BigObject : MonoBehaviour
{

    public ParticleSystem particleExplosion;

    public int objectLife;

    private bool _playOnce = true;
    
    // Update is called once per frame
    void Update()
    {
        if (objectLife <= 0 && _playOnce)
        {
            StartCoroutine(DisableObject());
            _playOnce = false;
            
        }
    }

    IEnumerator DisableObject()
    {
        particleExplosion.Play();
        GetComponent<SpriteRenderer>().sprite = null;
        GetComponent<PolygonCollider2D>().enabled = false;
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
public void Damage(int amount)
    {
        objectLife -= amount;
        Debug.Log(objectLife);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Camera.main.DOShakePosition(0.5f, 0.1f, 90, 0.5f);
            Camera.main.DOShakeRotation(0.5f, .1f, 90, .5f);
            Damage(1);
        }
    }
}
