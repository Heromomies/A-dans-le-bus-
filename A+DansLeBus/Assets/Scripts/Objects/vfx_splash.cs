using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfx_splash : MonoBehaviour
{
    public GameObject vfx_liquide;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Instantiate_obj()
    {
        GameObject vfx = Instantiate(vfx_liquide, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
