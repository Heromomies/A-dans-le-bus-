using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            }
        }
    }

    public void Damage(int amount)
    {
        objectLife -= amount;
    }
}
