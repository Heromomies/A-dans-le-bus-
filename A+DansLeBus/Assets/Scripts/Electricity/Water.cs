using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    
    #region singleton

    public static Water _instance;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    #endregion

    public GameObject electricityZone;
    public void CreateElectricity()
    {
        Debug.Log("Zone créée");
        Instantiate(electricityZone, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.5f);
    }
}
