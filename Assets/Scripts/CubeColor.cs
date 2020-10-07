using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Color.m)
        {
            
            GetComponent<Renderer>().material = Color.m;
           
        }
    
        Debug.Log("lal");
        Debug.Log(GetComponent<Transform>().position.x);
        Debug.Log(GetComponent<Transform>().position.y);
        Debug.Log(GetComponent<Transform>().position.z);
    }
}
