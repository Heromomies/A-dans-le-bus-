using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BigObject : MonoBehaviour
{

    public List<GameObject> objectToInstantiate;
    public List<Transform> spawnPoints;
    
    public int objectLife;
    
    // Update is called once per frame
    void Update()
    {
        if (objectLife <= 0)
        {
            foreach (var oti in objectToInstantiate)
            {
                int randomPos = Random.Range(0, spawnPoints.Count);
                Instantiate(oti, spawnPoints[randomPos].position, Quaternion.identity);
                spawnPoints.RemoveAt(randomPos);
            }
            Destroy(gameObject);
        }
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
