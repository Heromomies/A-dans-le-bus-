using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterEffect : MonoBehaviour
{
    public GameObject destroyable_obj;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            GameObject gameObject = Instantiate(destroyable_obj, transform.position, Quaternion.identity); ;
            Destroy(gameObject, 3f);
            Destroy(this.gameObject);
        }
       
    }
}
