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
    
    public void CreateElectricity()
    {
        //TODO instantiate zone electricity 
        Debug.Log("Zone electricity created");
    }
}
