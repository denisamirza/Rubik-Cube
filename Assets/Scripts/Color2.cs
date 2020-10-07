using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color2 : MonoBehaviour
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
        //throw new NotImplementedException();
        Color.m = GetComponent<Renderer>().material;
        Debug.Log(Color.m.name);
    }
}
